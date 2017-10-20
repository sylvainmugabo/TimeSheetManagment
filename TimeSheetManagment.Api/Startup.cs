using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagment.DataAccess.Abstract;
using TimeSheetManagment.DataAccess.Abstracts;

namespace TimeSheetManagment.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _config = builder.Build();
        }

        private IConfigurationRoot _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton(_config);
            services.AddDbContext<Data.TimeSheetManagmentDBContext>(options =>
                            options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(DataAccess.Repository.RepositoryBase<>));
            services.AddScoped(typeof(IDataAccessLayerBase<>), typeof(DataAccess.DAL.DataAccessLayerBase<>));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                                    .WithMethods("GET")
                                    .WithOrigins("http://localhost:4200")
                    );
            });


            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
