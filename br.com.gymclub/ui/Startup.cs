using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.context;
using api.models;
using api.repositories;
using api.repositories.Interfaces;
using api.services;
using api.services.Interfaces;
using AutoMapper;
using helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using services;
using settings;
using ui.repositories;

namespace ui
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
            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);
            var connectionStriing = appSettings.Get<AppSettings>().MySqlConnectionString;
            services.AddDbContext<AppDbContext>
                (options => options.UseMySql(connectionStriing));

            services.AddScoped<IPasswordManager, PasswordManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<ILesssonRepository, LessonsRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IPlanTypeRepository, PlanTypeRepository>();
            services.AddScoped<ITypepaymentRepository, TypePaymentRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPlanTypeService, PlanTypeService>();
            services.AddScoped<ITypePaymentService, TypePaymentService>();

            services.AddScoped<IInstructorService, InstructorService<Instructor>>();
            services.AddScoped<IPaymentService, PaymentService<Payment>>();
            services.AddScoped<IStateService, StateService>();

            /*var key = Encoding.ASCII.GetBytes(appSettings.Get<AppSettings>().JWTSecret);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };*/
            //    })
            // authentication
          
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => {
                 
                options.LoginPath = "/auth";
                    
                 
            });
            services.AddDistributedMemoryCache();
        

        services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "GymClub",
                    Version = "v1",
                    Description = "GymClub API "

                });
                
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            }
                );
            services.AddControllersWithViews();
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
            app.Use(async (context, next) =>
            {

                await next();
                if (context.Response.StatusCode == 403)
                {
                   
                    var newPath = new PathString("/Auth/withoutaccess");
                    var originalPath = context.Request.Path;
                    var originalQueryString = context.Request.QueryString;
                    context.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature()
                    {
                        OriginalPathBase = context.Request.PathBase.Value,
                        OriginalPath = originalPath.Value,
                        OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null,
                    });

                    // An endpoint may have already been set. Since we're going to re-invoke the middleware pipeline we need to reset
                    // the endpoint and route values to ensure things are re-calculated.
                    context.SetEndpoint(endpoint: null);
                    var routeValuesFeature = context.Features.Get<IRouteValuesFeature>();
                    routeValuesFeature?.RouteValues?.Clear();

                    context.Request.Path = newPath;
                    try
                    {
                        await next();
                    }
                    finally
                    {
                        context.Request.QueryString = originalQueryString;
                        context.Request.Path = originalPath;
                        context.Features.Set<IStatusCodeReExecuteFeature>(null);
                    }

                    // which policy failed? need to inform consumer which requirement was not met
                    //await next();
                }
                if (context.Response.StatusCode == 401)
                {
                   
                    var newPath = new PathString("/Auth");
                    var originalPath = context.Request.Path;
                    var originalQueryString = context.Request.QueryString;
                    context.Features.Set<IStatusCodeReExecuteFeature>(new StatusCodeReExecuteFeature()
                    {
                        OriginalPathBase = context.Request.PathBase.Value,
                        OriginalPath = originalPath.Value,
                        OriginalQueryString = originalQueryString.HasValue ? originalQueryString.Value : null,
                    });

                    // An endpoint may have already been set. Since we're going to re-invoke the middleware pipeline we need to reset
                    // the endpoint and route values to ensure things are re-calculated.
                    context.SetEndpoint(endpoint: null);
                    var routeValuesFeature = context.Features.Get<IRouteValuesFeature>();
                    routeValuesFeature?.RouteValues?.Clear();

                    context.Request.Path = newPath;
                    try
                    {
                        await next();
                    }
                    finally
                    {
                        context.Request.QueryString = originalQueryString;
                        context.Request.Path = originalPath;
                        context.Features.Set<IStatusCodeReExecuteFeature>(null);
                    }

                    // which policy failed? need to inform consumer which requirement was not met
                    //await next();
                }

            });
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GymClub API");

            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
            });
           
        }
    }
}
