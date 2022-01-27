using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.User
{
    public class MeService : IMeService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;


        public MeService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration, IHttpContextAccessor contextAccessor, IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public async Task<UserResponseDto> GetCurrentUserProfileAsync()
        {
            var currentHttpContextUser = _contextAccessor.HttpContext.User.Identities.FirstOrDefault();

            if (currentHttpContextUser != null)
            {
                var currentUserId = currentHttpContextUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var applicationUser = await _userRepository.GetByIdAsync(currentUserId);
                var roles = await _userManager.GetRolesAsync(applicationUser);
                var dto = _mapper.Map<UserResponseDto>(applicationUser);

                foreach (var role in roles)
                {
                    dto.Role = role;
                }

                return dto;
            }

            return null;
        }
        public async Task<LoginResult> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginRequestDto.UserName, loginRequestDto.Password, isPersistent: false,
 lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginRequestDto.UserName);
                var applicationUser = _userRepository.GetByIdAsync(user.Id);
                var claims = await GetClaimsFromUser(user);
                var jwtToken = GetJwtTokenForUser(user, claims);
                var role = await _userManager.GetRolesAsync(user);

                // Creating the ClaimsIdentity
                var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                // Creating the ClaimsPrincipal
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                // Sign in, in the context
                await _contextAccessor.HttpContext.SignInAsync(claimsPrincipal);

                return new LoginResult { Succeeded = true, JwtToken = jwtToken, Role = role[0]  };
            }
            else
            {
                return new LoginResult
                {
                    Succeeded = false,
                    ErrorMessages = new List<string> {
                        "Something went wrong, please try again"
                    },
                    JwtToken = null
                };
            }
        }
        public async Task<RegisterResult> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                UserName = registerRequestDto.UserName,
                Birthday = registerRequestDto.Birthday,
                Email = registerRequestDto.EmailAddress,
                FirstName = registerRequestDto.FirstName,
                LastName = registerRequestDto.LastName,
                //Image = Image
            };

            var resultCreateUser = await _userManager.CreateAsync(appUser, registerRequestDto.Password);

            if (resultCreateUser.Succeeded)
            {

                return new RegisterResult { Succeeded = true };
            }
            else
            {
                return GetRegisterResultWithErrorMessages(resultCreateUser);
            }
        }

        private string GetJwtTokenForUser(ApplicationUser user, IList<Claim> claims)
        {
            var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey),
                SecurityAlgorithms.HmacSha256)
            );

            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token); //serialize the token
            return serializedToken;
        }

        private async Task<IList<Claim>> GetClaimsFromUser(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id));
            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

        private RegisterResult GetRegisterResultWithErrorMessages(IdentityResult identityResult)
        {
            var errorMessages = new List<string>();

            foreach (var identityError in identityResult.Errors)
            {
                errorMessages.Add($"{identityError.Code} - {identityError.Description}{Environment.NewLine}");
            }

            return new RegisterResult { Succeeded = false, ErrorMessages = errorMessages };
        }
    }
}
