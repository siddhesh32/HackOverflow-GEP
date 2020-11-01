using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Concreate;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class EntityConfigurationBL : IEntityConfigurationBL
    {
        ICosmosDBService _cosmosDBService;
        public EntityConfigurationBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<IEnumerable<EntityConfig>> GetEntityConfigList()
        {
            IEnumerable<EntityConfig> entityConfigs = await _cosmosDBService.GetItemsAsync<EntityConfig>("select * from entity", "", "");
            return entityConfigs;
        }

        public async Task SaveEntityConfig(EntityConfig entityConfig)
        {
           await _cosmosDBService.AddItemAsync<EntityConfig>(entityConfig);
        }

        public async Task UpdateEntityConfig(string Id, EntityConfig entityConfig)
        {
           await _cosmosDBService.UpdateItemAsync(Id, entityConfig);
        }
    }
}
