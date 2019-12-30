using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceStackDemo.Host.Model;
using ServiceStackDemo.Core;
using ServiceStackDemo.Domain.Repository;
using ServiceStackDemo.Db;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace ServiceStackDemo.Host
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var config = ConfigurationBinder.Get<Authentication>(Configuration.GetSection(typeof(Authentication).Name));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.Audience = config.JwtBearer.Audience;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtBearer.SecurityKey)),

                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = config.JwtBearer.Issuer,

                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = config.JwtBearer.Audience,

                    // Validate the token expiry
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info() { Title = "MyApi", Version = "V1" });

                options.AddSecurityDefinition("MyApi", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDbConnection(Configuration);
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

            }); // URL: /swagger
        }


    }
}
