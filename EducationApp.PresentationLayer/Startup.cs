using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;

namespace EducationApp.PresentationLayer
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                 
            services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AspNetCoreIdentityDb"),
            optionsBuilder =>
            optionsBuilder.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name)));
            services.AddIdentityCore<IdentityUser>(options => { });
            services.AddScoped<IUserStore<IdentityUser>, UserOnlyStore<IdentityUser, IdentityDbContext>>();

            string connection = Configuration["ConnectionString:EmployeeDB"];
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connection));
            services.AddTransient<Users>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddIdentity<Users, Roles>(o => {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })

                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            //Jwt Token
            const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65KYKARA4A666Masssaraksh07fcalskd234n1k41230";
            var signingKey = new SymmetricKey(signingSecurityKey);
            services.AddSingleton<IJwtPrivateKey>(signingKey);

            const string jwtSchemeName = "JwtBearer";
            var signingDecodingKey = (IJwtPrivateKey)signingKey;
            services
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = jwtSchemeName;
                    options.DefaultChallengeScheme = jwtSchemeName;
                })
                .AddJwtBearer(jwtSchemeName, jwtBearerOptions => {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingDecodingKey.GetKey(),
                        ValidateIssuer = true,
                        ValidIssuer = "MyJwt",
                        ValidateAudience = true,
                        ValidAudience = "TheBestClient",
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromSeconds(5)
                    };
                });


          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
           
        }
    }

    internal class MinimumAgeRequirement : IAuthorizationRequirement
    {
    }
}
