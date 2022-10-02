using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ZHL.GUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   // electron.net
                //   webBuilder.UseElectron(args);
#if DEBUG
                   webBuilder.UseEnvironment("Development");
#endif
                   // start razor pages
                   webBuilder.UseStartup<Startup>();

               //    webBuilder.Services.AddAuthentication(options => {
               //        // This forces challenge results to be handled by Google OpenID Handler, so there's no
               //        // need to add an AccountController that emits challenges for Login.
               //        options.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
               //
               //        // This forces forbid results to be handled by Google OpenID Handler, which checks if
               //        // extra scopes are required and does automatic incremental auth.
               //        options.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
               //
               //        // Default scheme that will handle everything else.
               //        // Once a user is authenticated, the OAuth2 token info is stored in cookies.
               //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               //                        })
               //     .AddCookie(options => {
               //         options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
               //     })
               //     .AddGoogleOpenIdConnect(options => {
               //         var secrets = GoogleClientSecrets.FromFile("client_secret.json").Secrets;
               //         options.ClientId = secrets.ClientId;
               //         options.ClientSecret = secrets.ClientSecret;
               //     });
               });
        }
    }
}

/*

    var builder = WebApplication
                .CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

*/