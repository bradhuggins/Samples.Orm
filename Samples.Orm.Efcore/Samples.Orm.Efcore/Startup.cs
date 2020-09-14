#region Using Statements
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Samples.Orm.Efcore.Models;
#endregion

namespace Samples.Orm.Efcore
{
    public class Startup
    {
        public static readonly LoggerFactory DbDebugLoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //setup entity framework
            services.AddDbContext<AppDbContext>(
                    options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                        //,providerOptions => providerOptions.EnableRetryOnFailure()
                        )
                    .EnableSensitiveDataLogging()

                    //.UseLoggerFactory(DbDebugLoggerFactory) 
                    // Warning: Do not create a new ILoggerFactory instance each time
                    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/logging
                );

            services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Samples.Orm.Efcore API", Version = "v1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Company.SampleApp API v1.0");

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
