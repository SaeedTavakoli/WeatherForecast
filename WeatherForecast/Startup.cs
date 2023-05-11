using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFramework.Configuration;
using WebFramework.CustomMapping;
using WebFramework.Middlewares;
using WebFramework.Swagger;

namespace WeatherForecast
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly SiteSettings _siteSetting;
        private readonly IWebHostEnvironment _currentEnvironment;


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));

            services.AddDbContext(Configuration);

            services.AddMinimalMvc();

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCustomExceptionHandler();

            app.UseHsts(env);

            app.UseHttpsRedirection();

            app.UseSwaggerAndUI();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //Use this config just in Develoment (not in Production)
            app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });

        }
    }
}
