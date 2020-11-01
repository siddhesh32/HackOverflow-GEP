using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFieldMapper.WebAPI.Installers
{
    public class SwaggerInstaller:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("V0", new OpenApiInfo
                {
                    Title = "Hackoverflow API",
                    Version = "V0",
                    Contact = new OpenApiContact
                    {
                        Name = "Hackoverflow",
                        Email = "siddhesh.chavan@gep.com"
                    }

                });


                /* The below configuration is needed to uniquely identify duplicate view model 
                 * classes under the different versions of Contracts. 
                 */
                config.CustomSchemaIds(c => c.FullName);

                config.IncludeXmlComments("SmartFieldMapper.WebAPI.xml");

                config.AddFluentValidationRules();

            });
        }
    }
}
