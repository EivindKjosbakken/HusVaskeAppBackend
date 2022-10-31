using HusVaskeIdeBackend.Models.TodoItem;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HusVaskeIdeBackend.Models.AuthData;
using HusVaskeIdeBackend.Models.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using HusVaskeIdeBackend.Data;

namespace HusVaskeIdeBackend
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
            services.AddRazorPages();
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(c => c.SwaggerDoc(name:"v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" }));
            services.AddControllers();

            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration.GetValue<string>("JWTSecretKey"))
                        )
                    };
                });




            services.AddSingleton(
                    new AuthService(
                        Configuration.GetValue<string>("JWTSecretKey"),
                        Configuration.GetValue<int>("JWTLifespan")
                    )
                );
                services
                    .AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //this is normally used
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "My API V1"));

            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
