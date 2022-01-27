using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Licensing;

namespace Imi.Project.Vue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SyncfusionLicenseProvider.RegisterLicense("NTQ3NzczQDMxMzkyZTMzMmUzMFdGNmlzK3hmYVFkY3ZYcmZDeTlqUkQyZWZHdEhvdW1wRWEwT21yOWpydjA9;NTQ3Nzc0QDMxMzkyZTMzMmUzMEJablV6WlNaaG1KVUNyZ0Faak5UdkdMOVk4SnVVU09DTjRXQmhtSDJ5eHM9;NTQ3Nzc1QDMxMzkyZTMzMmUzMGx0Nng0TktkK0p4R0lZbmwzM3JPcjl0QUNSSHo2eUdTOTMvQVN0RzdJKzQ9;NTQ3Nzc2QDMxMzkyZTMzMmUzMGtGTlRjbnNzNC81cWRKa2g2b1lOQlFaVFZXR01KbHI0YmVkUU5pcHdab3c9;NTQ3Nzc3QDMxMzkyZTMzMmUzMEFEbGk0UDcvM2hLT015SlJ3YkhrTWFCZ3diaVR1N2I3QVE1dEFsY0wzSWM9");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //SyncfusionLicenseProvider.RegisterLicense("NTQ3NzczQDMxMzkyZTMzMmUzMFdGNmlzK3hmYVFkY3ZYcmZDeTlqUkQyZWZHdEhvdW1wRWEwT21yOWpydjA9;NTQ3Nzc0QDMxMzkyZTMzMmUzMEJablV6WlNaaG1KVUNyZ0Faak5UdkdMOVk4SnVVU09DTjRXQmhtSDJ5eHM9;NTQ3Nzc1QDMxMzkyZTMzMmUzMGx0Nng0TktkK0p4R0lZbmwzM3JPcjl0QUNSSHo2eUdTOTMvQVN0RzdJKzQ9;NTQ3Nzc2QDMxMzkyZTMzMmUzMGtGTlRjbnNzNC81cWRKa2g2b1lOQlFaVFZXR01KbHI0YmVkUU5pcHdab3c9;NTQ3Nzc3QDMxMzkyZTMzMmUzMEFEbGk0UDcvM2hLT015SlJ3YkhrTWFCZ3diaVR1N2I3QVE1dEFsY0wzSWM9");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });
        }
    }
}
