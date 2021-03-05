using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using MediatR;
using MelloApiV4.Common;
using MelloApiV4.Data;
using MelloApiV4.Data.Connections;
using MelloApiV4.Data.Entities.Translation;
using MelloApiV4.Data.Repository;
using MelloApiV4.Data.Repository.WordTranslations;
using MelloApiV4.Queries;
using MelloApiV4.Repository;
using MelloApiV4.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MelloApiV4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public CommandsConnectionString CommandsConnectionString { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public QueriesConnectionString QueriesConnectionString { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);

            ConfigureAppSettings(services);

            ConfigureStorage(services);

            services
                .AddMvcCore();
            services
                .AddCors();
            services
                .AddMvc();

            services
            .AddMediatR(typeof(TestResult));

            services.AddControllers();

        }

        protected virtual void RegisterConnectionsIfPresent(IServiceCollection services)
        {
            var queriesConnectionStringOrError = QueriesConnectionString.Create(Environment.GetEnvironmentVariable("DB")); //(Configuration["MelloDBConnString"]); //Configuration.QueriesConnectionString());
            if (queriesConnectionStringOrError.IsSuccess)
            {
                QueriesConnectionString = queriesConnectionStringOrError.Value;
                services.AddSingleton(QueriesConnectionString);
            }

            var commandsConnectionStringOrError = CommandsConnectionString.Create(Environment.GetEnvironmentVariable("DB")); //Configuration.CommandsConnectionString());
            if (commandsConnectionStringOrError.IsSuccess)
            {
                CommandsConnectionString = commandsConnectionStringOrError.Value;
                services.AddSingleton(CommandsConnectionString);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UsePathBase($"/api");
            app.UseRouting();

            app.UseStaticFiles();
            app.UseStatusCodePages();
            //app.UseAuthorization();

            app.UseCors(Constants.Cors.AllowAllPolicy);


            ConfigureEntityMappings();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           // if (!string.IsNullOrWhiteSpace(pathBase))
            //{

            //}



        }

        protected virtual void RegisterServices(IServiceCollection services)
        {
            // Registrer connection if present
           RegisterConnectionsIfPresent(services);

            // Singleton Classes
            services.AddSingleton(new System.Net.Http.HttpClient());
            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<IWordTranslationsRepository, WordTranslationsRepository>();

            services.AddScoped<IActionResultFactory, ActionResultFactory>();

            services.AddTransient<IConnectionFactory, SqlConnectionFactory>();

            // Database
            services.AddScoped(typeof(IDatabaseWriter<>), typeof(DapperDatabaseWriter<>));
            services.AddScoped(typeof(IDatabaseReader<>), typeof(DapperDatabaseReader<>));

            // Builders
            services.AddScoped<IValidationResponseModelBuilder, ValidationResponseModelBuilder>();
            services.AddScoped<IExceptionResponseModelBuilder, ExceptionResponseModelBuilder>();

        }

        protected virtual void ConfigureEntityMappings()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddEntityMapping(new TranslationEntityMap());
                config.ForDommel();
            });
        }

        protected virtual void ConfigureAppSettings(IServiceCollection services)
        {
            

            services
                .AddOptions();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        protected virtual void ConfigureStorage(IServiceCollection services)
        {
            services
                .AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(CommandsConnectionString.Value));//CommandsConnectionString.Value));
        }
    }
}
