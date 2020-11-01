using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class EntityConfigurationBL : IEntityConfigurationBL
    {
        private const string PARTITION_KEY = "Contract";
        private const string CONTAINER_NAME = "EntityConfig";
        ICosmosDBService _cosmosDBService;
        public EntityConfigurationBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<IEnumerable<EntityConfig>> GetEntityConfigList()
        {
            IEnumerable<EntityConfig> entityConfigs = await _cosmosDBService.GetItemsAsync<EntityConfig>("select * from entity", CONTAINER_NAME);
            return entityConfigs;
        }

        public async Task SaveEntityConfig(EntityConfig entityConfig)
        {
           await _cosmosDBService.AddItemAsync(entityConfig, CONTAINER_NAME);
        }

        public async Task UpdateEntityConfig(UpdateEntityConfigRequest updateEntityConfigRequest)
        {
           await _cosmosDBService.UpdateItemAsync(updateEntityConfigRequest.Id, updateEntityConfigRequest.entityConfig, CONTAINER_NAME, PARTITION_KEY);
        }
    }
}
