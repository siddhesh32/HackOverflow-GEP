using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartFieldMapper.WebAPI.Installers
{
    /// <summary>
    /// Common Interface For Installer
    /// </summary>
    public interface IInstaller
    {
        /// <summary>
        /// Install Services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
