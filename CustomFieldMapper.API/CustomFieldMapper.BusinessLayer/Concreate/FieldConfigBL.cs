using SmartFieldMapper.BusinessLayer.Entities;
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
        private readonly ICosmosDBService _cosmosDBService;
        public FieldConfigBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<FieldConfig> GetFieldConfiguration(string Id)
        {
            FieldConfig fieldConfig = await _cosmosDBService.GetItemAsync<FieldConfig>(Id);
            return fieldConfig;
        }

        public void SaveFieldConfiguration(FieldConfig fieldConfig)
        {
            _cosmosDBService.AddItemAsync(fieldConfig);
        }

        public void UpdateFieldConfiguration(string Id,FieldConfig fieldConfig)
        {
            _cosmosDBService.UpdateItemAsync(Id, fieldConfig);
        }
    }
}
