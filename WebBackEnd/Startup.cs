using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WebBackEnd.DAL;
using WebBackEnd.Domains.Posts;
using System.IO;
using System.Reflection;
using WebBackEnd.Domains.User;
using VkNet.Model;
using VkNet;

namespace WebBackEnd
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebBackEnd", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });

            services.AddScoped<PostsService>();
            services.AddScoped<UserService>();
            services.AddDbContext<WebBackEndContext>(options =>options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<VkApi>(provider =>
            {
                var vkApi = new VkApi();


                vkApi.Authorize(new ApiAuthParams
                {
                    AccessToken = "vk1.a.YwKD07sSCwRFOmp9YeF18FOOq3L-BXMj8tkVrjtcq-hN6Kf4Q7sdpedvGVW6PcDjsctbQGWarZdiR0US_K8HhpCS20zHLdh8-bLK0UYgb4EpCNNOvTsZH37VeTO0rxu2SIX7EHqmRWJUSAUp8qErJJjl4nqiCjFsjM4m3ylK6OZzTufFEm6j8xd-Gqm3hrPj"
                });

                return vkApi;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebBackEnd v1"));
            }

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
