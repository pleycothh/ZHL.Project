using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace ZHL.GUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();
           // services.AddElectron(); <- optional for Electron 
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<GUIModule>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            { 
                // nice error page for end users with back button
                app.UseExceptionHandler(c => c.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                    var response = new { error = exception.Message, stack = exception.StackTrace };
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes($"<!doctype html><html><head><link rel=\"stylesheet\" href=\"/lib/bootstrap/dist/css/bootstrap.min.css\"></head><body><div class=\"container\"><h1 class=\"text-danger\">Error.</h1><h2 class=\"text-danger\">An error occurred while processing your request.</h2><h3>{exception.Source}</h3><p>{response.error}</p><button onclick =\"history.back();\" class=\"btn btn-danger\">Go back</button><p>{response.stack}</p></div></body></html>"));
                }));
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

            ///Ensure that you are using Authorization and HttpsRedirection 

         //   app.UseHttpsRedirection();
         //   app.UseStaticFiles();
         //
         //   app.UseRouting();
         //
         //   app.UseAuthentication();
         //   app.UseAuthorization();
        }
    }
}
