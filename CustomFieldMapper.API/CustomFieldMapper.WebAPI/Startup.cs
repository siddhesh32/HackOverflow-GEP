using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartFieldMapper.DataAccessLayer.Concreate;
using SmartFieldMapper.WebAPI;
using SmartFieldMapper.WebAPI.Installers;
using SmartFieldMapper.WebAPI.MIddleWare;
using System.Threading.Tasks;

namespace CustomFieldMapper.WebAPI
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InstallExtentions.InstallServicesInAssembly(services, Configuration);
            services.AddControllers();
        }
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
            // Swagger integration
            var swaggerOption = new SwaggerOption();
            Configuration.GetSection(nameof(SwaggerOption)).Bind(swaggerOption);

            //Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOption.JsonRoute;
            });

            app.UseSwaggerUI(option =>
            {
                foreach (var uiEndpoint in swaggerOption.SwaggerUIEndpoints)
                {
                    option.SwaggerEndpoint(uiEndpoint.Endpoint, uiEndpoint.Description);
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Middleware to run the startup entry for the API request
            app.UseMiddleware<SmartFieldMiddleware>();
        }
        /// <summary>
        /// Initialize Cosmos Client Instance Async
        /// </summary>
        /// <param name="configurationSection"></param>
        /// <returns></returns>
        public static async Task<CosmosDBService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;
            CosmosClient client = new CosmosClient(account, key);
            CosmosDBService cosmosDbService = new CosmosDBService();
            cosmosDbService.dbClient = client;
            cosmosDbService.database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            //await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return cosmosDbService;
        }
    }
}
