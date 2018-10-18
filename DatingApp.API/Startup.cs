using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API
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
             byte [] key=Encoding.ASCII.GetBytes(Configuration .GetSection("secrets:HashSalt").Value);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(config => {
                        config.TokenValidationParameters = new TokenValidationParameters () {
                            ValidateAudience=false,
                            IssuerSigningKey =new SymmetricSecurityKey(key) ,
                            ValidateIssuer=false,
                            ValidateIssuerSigningKey=true
                            


                        };

            });
        
         services.AddDbContext<DataContext>(config => {

config.UseSqlServer(Configuration.GetConnectionString("Default"));
         });
        services.AddTransient<IDatingAppRepository , DatingAppRepository>();
        services.AddScoped<IAuthrepository, AuthRepository>();
         services.AddCors();
         services.AddAutoMapper();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder => builder.Run(

                    async context => {
                      var feature=  context.Features.Get<IExceptionHandlerFeature>();
                      context.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                        context.Response.AddApplicationError(feature.Error.Message);
                    await   context.Response.WriteAsync(feature.Error.Message);
                      
                        

                    }
                ));
            }
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
