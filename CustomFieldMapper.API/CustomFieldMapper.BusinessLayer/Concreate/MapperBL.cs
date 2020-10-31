using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class MapperBL : IMapperBL
    {
        private readonly ICosmosDBService _cosmosDBService = null;
        public MapperBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<Form> GetAllData()
        {
            string query = "Select * from C";
            dynamic obj = await _cosmosDBService.GetItemsAsync(query);
            return DynamicToStatic.ToStatic<Form>(obj);
        }
    }
}
