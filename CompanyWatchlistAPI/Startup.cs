using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using CompanyWatchlistAPI.Repositories.Interfaces;
using CompanyWatchlistAPI.Repositories;
using CompanyWatchlistAPI.Services.Interfaces;
using CompanyWatchlistAPI.Services;

namespace CompanyWatchlistAPI
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public IWebHostEnvironment HostingEnvironment { get; private set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddMemoryCache();

                services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

                services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));

                #region "Authentication"

                //JWT API authentication service
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                }
                 );
                #endregion

                #region "CORS"
                // include support for CORS
                // More often than not, we will want to specify that our API accepts requests coming from other origins (other domains). When issuing AJAX requests, browsers make preflights to check if a server accepts requests from the domain hosting the web app. If the response for these preflights don't contain at least the Access-Control-Allow-Origin header specifying that accepts requests from the original domain, browsers won't proceed with the real requests (to improve security).
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy-public",
                        builder => builder.AllowAnyOrigin()   //WithOrigins and define a specific origin to be allowed (e.g. https://mydomain.com)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                    //.AllowCredentials()
                    .Build());
                });
                #endregion

                #region "MVC and JSON options"
                //mvc service (set to ignore ReferenceLoopHandling in json serialization like Users[0].Account.Users)
                //in case you need to serialize entity children use commented out option instead
                services.AddMvc(option =>
                {
                    option.EnableEndpointRouting = false;
                })
                    .AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
                #endregion

                #region "DI code"
                //auth DI
                services.AddHttpContextAccessor();

                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IRoleRepository, RoleRepository>();
                services.AddScoped<IWatchlistRepository, WatchlistRepository>();

                services.AddScoped<IEncryptionService, EncryptionService>();

                services.AddTransient<JwtSecurityTokenHandler>();

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                app.UseCors("CorsPolicy-public");  //apply to every request
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthentication(); //needs to be up in the pipeline, before MVC
                app.UseAuthorization();

                app.UseMvc();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
