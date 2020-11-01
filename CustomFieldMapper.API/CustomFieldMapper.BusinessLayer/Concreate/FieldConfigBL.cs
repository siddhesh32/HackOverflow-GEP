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
    public class FieldConfigBL : IFieldConfigBL
    {
        private const string PARTITION_KEY = "CONTRACT";
        private const string CONTAINER_NAME = "FieldConfig";
        private readonly ICosmosDBService _cosmosDBService;
        private readonly IApiHeaders _apiHeaders;
        public FieldConfigBL(ICosmosDBService cosmosDBService,IApiHeaders apiHeaders)
        {
            _cosmosDBService = cosmosDBService;
            _apiHeaders = apiHeaders;
        }
        public async Task<FieldConfig> GetFieldConfiguration(string Id)
        {
            FieldConfig fieldConfig = await _cosmosDBService.GetItemAsync<FieldConfig>(Id, CONTAINER_NAME, PARTITION_KEY);
            return fieldConfig;
        }

        public void SaveFieldConfiguration(FieldConfig fieldConfig)
        {
            if (string.IsNullOrEmpty(fieldConfig.Id))
            {
                fieldConfig.PartitionKey = PARTITION_KEY;
                fieldConfig.Id = "FieldConfig-" + _apiHeaders.BPC;
                _cosmosDBService.AddItemAsync(fieldConfig, CONTAINER_NAME);
            }
            else
            {
                _cosmosDBService.UpdateItemAsync(fieldConfig.Id, fieldConfig, CONTAINER_NAME, PARTITION_KEY);
            }
            
        }

        public void UpdateFieldConfiguration(UpdateFieldConfigRequest updateFieldConfigRequest)
        {
            updateFieldConfigRequest.fieldConfig.Id = "FieldConfig" + _apiHeaders.BPC;
            _cosmosDBService.UpdateItemAsync(updateFieldConfigRequest.Id, updateFieldConfigRequest.fieldConfig, CONTAINER_NAME, PARTITION_KEY);
        }
    }
}
