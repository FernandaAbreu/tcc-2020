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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using services;

using settings;

namespace api
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
            services.AddCors();
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IClientService, ClientService>();
           
            services.AddScoped<IInstructorService, InstructorService<Instructor>>();
            services.AddScoped<IPaymentService, PaymentService<Payment>>();
            services.AddScoped<IStateService, StateService>();

            var key = Encoding.ASCII.GetBytes(appSettings.Get<AppSettings>().JWTSecret);
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
                        
                    };
                });

             services.AddAutoMapper(typeof(Startup));
             services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                 {
                     Title = "GymClub",
                     Version = "v1",
                     Description = "GymClub API "

                 });
                 c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = "JWT Authorization header using 'bearer' scheme",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey
                 });
                 c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {new OpenApiSecurityScheme{Reference = new OpenApiReference
                     {
                         Id = "Bearer",
                         Type = ReferenceType.SecurityScheme
                     }}, new List<string>()}
                 });
                 c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
             }
                 );
            /*c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using 'bearer' scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {new OpenApiSecurityScheme{Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }}, new List<string>()}
            });*/
            //});
            services.AddControllersWithViews();
            services.AddRazorPages();
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

            //app.UseHttpsRedirection();
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
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
