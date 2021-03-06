﻿using CustomFieldMapper.WebAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SmartFieldMapper.WebAPI.Installers
{
    /// <summary>
    /// Install Extentions
    /// </summary>
    public static class InstallExtentions
    {
        /// <summary>
        /// Install Services In Assembly
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) &&
                    !x.IsInterface &&
                    !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
