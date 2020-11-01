using CustomFieldMapper.WebAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartFieldMapper.BusinessLayer.Concreate;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Concreate;
using SmartFieldMapper.DataAccessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Installers
{
    /// <summary>
    /// DI Installer
    /// </summary>
    public class DIInstaller:IInstaller
    {
        /// <summary>
        /// Install Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICosmosDBService>(Startup.InitializeCosmosClientInstanceAsync(configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
            services.AddTransient<IDocumentBL, DocumentBL>();
            services.AddTransient<IEntityConfigurationBL, EntityConfigurationBL>();
            services.AddTransient<IFieldConfigBL, FieldConfigBL>();
            services.AddTransient<ITemplateBL, TemplateBL>();
            services.AddScoped<IApiHeaders, ApiHeaders>();
        }
    }
}
