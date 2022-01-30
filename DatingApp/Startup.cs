using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DatingApp.DataLayer;
using DatingApp.Entities;
using Microsoft.AspNetCore.Identity;
using DatingApp.RepositoryLayer.Interface;
using DatingApp.RepositoryLayer;
//using Microsoft.OpenApi.Models;

namespace DatingApp
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
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            services.AddControllersWithViews();
            // For Entity Framework  

            services.AddDbContext<DatingAppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // For Identity  
            services.AddIdentity<UserMaster, IdentityRole>()
                .AddEntityFrameworkStores<DatingAppDbContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //DI - Used for Loosly coupling - no need to wait for the low level object to create a object
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminServices, AdminServices>();

            services.AddScoped<IFeedBackRepository, FeedBackRepository>();
            services.AddScoped<IFeedBackService, FeedBackService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors("CorsPolicy");
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatingApp");
            });
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
