using AspNet.Security.OpenIdConnect.Primitives;
using ASPPIC.Client.Web.Resources;
using ASPPIC.Public.Business.Concrete;
using ASPPIC.Public.Business.Interfaces;
using ASPPIC.Public.Domain.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace ASPPIC.Public.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<APIConfiguration>(Configuration.GetSection("APIS"));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddTransient<ITutorialService, TutorialService>();
            services.AddTransient<ITutorialGroupService, TutorialGroupService>();
            services.AddTransient<ICountyService, CountyService>();

            var authority = Configuration.GetSection(Constants.KeycloakUrl).Value + Constants.KeycloakRealm;
            var clientId = Configuration.GetSection(Constants.KeycloakClientId).Value;
            var clientSecret = Configuration.GetSection(Constants.KeycloakClientSecret).Value;
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddOpenIdConnect(options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = authority;
                    options.ClientId = clientId;
                    options.ClientSecret = clientSecret;
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.RequireHttpsMetadata = false;
                    options.Scope.Add(OpenIdConnectConstants.Scopes.Email);
                    options.Scope.Add(OpenIdConnectConstants.Scopes.Profile);
                    options.Scope.Add(OpenIdConnectConstants.Scopes.OpenId);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = OpenIdConnectConstants.Claims.Name,
                        RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                        ValidateIssuer = true,
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RegularUsers", policy => policy.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "regular-user"));
                options.AddPolicy("MedicalPersonnel", policy => policy.RequireClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "medical-personnel-user"));
            });
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
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
