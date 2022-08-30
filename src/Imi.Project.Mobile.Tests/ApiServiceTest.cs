using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Imi.Project.Mobile.Tests
{
    public class ApiServiceTest
    {
        MovieResponseDto[] testMovies;
        public ApiServiceTest()
        {
            testMovies = TestData.TestMovies;
        }

        [Fact]
        public void GetAll_Returns_AllMovies()
        {
            //arrange
            var mockMovieApiService = new Mock<IApiService<MovieResponseDto, MovieRequestDto>>();
            mockMovieApiService.Setup(serv => serv.GetAllAsync()).Returns(Task.FromResult((IEnumerable<MovieResponseDto>)testMovies));

            var expectedResults = testMovies;
            var movieService = mockMovieApiService.Object;

            //act
            var actualResult = movieService.GetAllAsync().Result;

            //assert
            Assert.Equal(expectedResults, actualResult);
        }

        [Fact]
        public void GetByID_Returns_CorrectMovieWithId()
        {
            var testMovie = testMovies[0];
            //arrange
            var mockMovieApiService = new Mock<IApiService<MovieResponseDto, MovieRequestDto>>();
            mockMovieApiService.Setup(serv => serv.GetByIdAsync(testMovie.Id.ToString())).Returns(Task.FromResult(testMovie));

            var expectedResults = testMovie;
            var movieService = mockMovieApiService.Object;

            //act
            var actualTestMovie = movieService.GetByIdAsync(testMovie.Id.ToString()).Result;
            //assert
            Assert.Equal(testMovie.Id, actualTestMovie.Id);
        }

        [Fact]
        public void GetAllMoviesByNameSearch_Returns_AllMoviesWithNameThatResemblesSearch()
        {
            string search = "movie";
            //arrange
            var mockMovieApiService = new Mock<IApiService<MovieResponseDto, MovieRequestDto>>();
            mockMovieApiService.Setup(serv => serv.GetAllAsync(search)).Returns(Task.FromResult(testMovies.Where(x => x.Name.ToUpper().Contains(search.ToUpper()))));

            var expectedResult = testMovies.Where(x => x.Name.ToUpper().Contains(search.ToUpper()));
            var movieService = mockMovieApiService.Object;

            //act
            var actualResult = movieService.GetAllAsync(search).Result;

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void CreateNewMovie_Returns_NewCreatedMovie()
        {
            //arrange
            var createdMovieReq = new MovieRequestDto { AverageRating = 7, Description = "7", Duration = 7, Id = 4, Name = "film7", ReleaseDate = DateTime.Today };
            var returnMovieresp = new MovieResponseDto { AverageRating = 7, Description = "7", Duration = 7, Id = 4, Name = "film7", ReleaseDate = DateTime.Today };

            var mockMovieApiService = new Mock<IApiService<MovieResponseDto, MovieRequestDto>>();
            mockMovieApiService.Setup(serv => serv.PostCallApi(createdMovieReq, "jwtToken")).Returns(Task.FromResult(returnMovieresp));
            var expectedResult = returnMovieresp;
            var movieService = mockMovieApiService.Object;

            //act
            var addNewMovie = movieService.PostCallApi(createdMovieReq, "jwtToken").Result;
            //assert
            mockMovieApiService.Verify(m => m.PostCallApi(createdMovieReq, "jwtToken"), Times.AtLeastOnce());
            Assert.NotNull(addNewMovie);
        }
    }
}
