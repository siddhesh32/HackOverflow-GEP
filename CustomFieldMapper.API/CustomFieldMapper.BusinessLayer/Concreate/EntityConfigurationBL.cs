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
        private const string PARTITION_KEY = "CONTRACT";
        private const string CONTAINER_NAME = "EntityConfig";
        private readonly ICosmosDBService _cosmosDBService;
        private readonly IApiHeaders _apiHeaders;
        public EntityConfigurationBL(ICosmosDBService cosmosDBService, IApiHeaders apiHeaders)
        {
            _cosmosDBService = cosmosDBService;
            _apiHeaders = apiHeaders;
        }
        public async Task<IEnumerable<EntityConfig>> GetEntityConfigList()
        {
            IEnumerable<EntityConfig> entityConfigs = await _cosmosDBService.GetItemsAsync<EntityConfig>("select * from entity", CONTAINER_NAME);
            return entityConfigs;
        }

        public async Task SaveEntityConfig(EntityConfig entityConfig)
        {
            if (string.IsNullOrEmpty(entityConfig.Id))
            {
                entityConfig.Id = Guid.NewGuid().ToString();
                entityConfig.PartitionKey = PARTITION_KEY +"-"+ _apiHeaders.BPC.ToString();
                await _cosmosDBService.AddItemAsync(entityConfig, CONTAINER_NAME);
            }
            else
            {
                await _cosmosDBService.UpdateItemAsync(entityConfig.Id, entityConfig, CONTAINER_NAME, PARTITION_KEY + "-" + _apiHeaders.BPC.ToString());
            }
           
        }

        public async Task UpdateEntityConfig(UpdateEntityConfigRequest updateEntityConfigRequest)
        {
           await _cosmosDBService.UpdateItemAsync(updateEntityConfigRequest.Id, updateEntityConfigRequest.entityConfig, CONTAINER_NAME, PARTITION_KEY + "-" + _apiHeaders.BPC.ToString());
        }
    }
}
