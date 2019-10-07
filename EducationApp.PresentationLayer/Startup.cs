using EducationApp.BusinessLogicLayer.Helpers;
using EducationApp.BusinessLogicLayer.Services;
using EducationApp.BusinessLogicLayer.Services.Interfaces;
using EducationApp.BusinessLogicLayer.Stripe.Infrastructure;
using EducationApp.DataAccessLayer.AppContext;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.EFRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
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
using Microsoft.OpenApi.Models;
using Stripe;
using System;
using System.Reflection;
using System.IO;

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
            var connectionString = Configuration["ConnectionStrings:EmployeeDB"];
            services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));
            services.AddIdentityCore<IdentityUser>();
            services.AddDefaultIdentity<Users>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationContext>();     
            services.AddScoped<IUserStore<IdentityUser>, UserOnlyStore<IdentityUser, IdentityDbContext>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPrintingEditionsRepository, PrintingEditionsRepository>();
            services.AddScoped<IPrintingEditionService, PrintingEditionService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddTransient<Users>();
            services.AddTransient<IEmailService, EmailHelper>();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Education", Version = "v1" });
                var xmlFile = "Swagger.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            //Jwt Refresh
            const string refreshSecurityKey = "0d5b3235a8132POPROBYI248673425609879rfghert545234n1k41230";
            var refreshKey = new JwtRefresh(refreshSecurityKey);
            services.AddSingleton<IJwtRefresh>(refreshKey);


            //Jwt Token
            const string accessSecurityKey = "0d5b3235a8b403c3dab9c3f4f65KYKARA4A666Masssaraksh07fcalskd234n1k41230";
            var accessKey = new JwtHelper(accessSecurityKey);
            services.AddSingleton<IJwtPrivateKey>(accessKey);

            const string jwtSchemeName = "JwtBearer";
            var signingDecodingKey = (IJwtPrivateKey)accessKey;
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
          
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Education V1");
            });
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
   

        }
    }
}
