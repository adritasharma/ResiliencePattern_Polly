using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResiliencePattern.Core.Services;
using ResiliencePattern.Infastructure;
using ResiliencePattern.Infastructure.Repositories;
using ResiliencePattern.Infastructure.Repositories.Employees.Contracts;
using ResiliencePattern.Infastructure.Repositories.Posts.Contracts;
using ResiliencePattern_Polly.Extensions;

namespace ResiliencePattern.WebAPI
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(ISampleRepository), typeof(SampleRepository));
            services.AddScoped(typeof(ISampleService), typeof(SampleService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));

            // services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

            services.AddHttpClientForPostService(Configuration);
            services.AddTransient<PostsUrlBuilder>();

            services.AddHttpClientForEmployeeService(Configuration);
            services.AddTransient<EmployeeUrlBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
