using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Interfaces;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class TemplateBL:ITemplateBL
    {
        private const string PARTITION_KEY = "Contract";
        private const string CONTAINER_NAME = "Template";
        private readonly ICosmosDBService _cosmosDBService;
        public TemplateBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public object GetTemplateById(string TemplateId)
        {
           return _cosmosDBService.GetItemAsync<object>(TemplateId, CONTAINER_NAME, PARTITION_KEY);
        }
    }
}
