using CustomFieldMapper.WebAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartFieldMapper.BusinessLayer.Concreate;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Installers
{
    public class DIInstaller:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICosmosDBService>(Startup.InitializeCosmosClientInstanceAsync(configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
            services.AddTransient<IMapperBL, MapperBL>();
        }
    }
}
