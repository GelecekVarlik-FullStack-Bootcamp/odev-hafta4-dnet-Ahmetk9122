using BMS.Bll;
using BMS.Dal.Abstract;
using BMS.Dal.Concrete.EntityFramework.Repository;
using BMS.Dal.Concrete.EntityFramework.UnitOfWork;
using BMS.Entity.Dto;
using BMS.Entity.Models;
using BMS.Interface;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.WebApi
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
            #region JwtTokenService
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
                {
                    cfg.SaveToken = true;
                    cfg.RequireHttpsMetadata = false;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                        RequireSignedTokens = true,
                        RequireExpirationTime = true //ExpirationTime kontrol etmesi zorunlu mu ? 
                    };
                });
           
            #endregion

            #region ApplicationContext
            services.AddDbContext<BMSDatabaseContext>();

          /*  services.AddDbContext<BMSDatabaseContext>
                (
                    ob => ob.UseSqlServer(Configuration.GetConnectionString("SqlServer"))
                );
          */
            services.AddScoped<DbContext, BMSDatabaseContext>();
            #endregion

            #region ServiceSection
            services.AddScoped<IManagerLoginService, ManagerLoginManager>();
            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IManagerLoginService, ManagerLoginManager>();
            services.AddScoped<IManagerLoginService, ManagerLoginManager>();
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IEmployeeLoginService, EmployeeLoginManager>();

            #endregion

            #region RepositorySection
            services.AddScoped<IManagerLoginRepository, ManagerLoginRepository>();
            services.AddScoped<IEmployeeLoginRepository, EmployeeLoginRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IWorkRepository, WorkRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
           
            #endregion

            #region UnitOfWork
            
            services.AddScoped<IUnitofWork, UnitofWork>();
            
            #endregion


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BMS.WebApi", Version = "v1" });
                //Authorization giriþ bloðu.
                #region TokenEntryBlock
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    //Token alma özellikleri
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme ="bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                  {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string [] { }
                  }
                });
                #endregion
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BMS.WebApi v1"));
            }
            //Authorization ekleme bloðu.
            #region Authorization
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BMS.WebApi v1");
            });
            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
