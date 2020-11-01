using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Concreate;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class DocumentBL : IDocumentBL
    {
        private readonly string PARTITION_KEY = string.Empty;
        private const string CONTAINER_NAME = "Document";
        private const string SELECT_QUERY = "Select * from "+ CONTAINER_NAME;
        ICosmosDBService _cosmosDBService;
        private readonly IApiHeaders _apiHeaders;
        public DocumentBL(ICosmosDBService cosmosDBService,IApiHeaders apiHeaders)
        {
            _cosmosDBService = cosmosDBService;
            _apiHeaders = apiHeaders;
            PARTITION_KEY = apiHeaders.BPC.ToString();
        }
        public async Task<Document> GetDocumentDataById(string Id)
        {
           return await _cosmosDBService.GetItemAsync<Document>(Id, CONTAINER_NAME, PARTITION_KEY);
        }

        public async Task SaveDocumentData(Document document)
        {
            if (string.IsNullOrEmpty(document.Id))
            {
                document.Id = System.Guid.NewGuid().ToString();
            }
            document.PartitionKey = _apiHeaders.BPC.ToString();
            await _cosmosDBService.AddItemAsync(document, CONTAINER_NAME);
        }

        public async Task UpdateDocumentData(Document document)
        {
           await  _cosmosDBService.UpdateItemAsync(document.Id, document, CONTAINER_NAME, PARTITION_KEY);
        }
        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await _cosmosDBService.GetItemsAsync<Document>(SELECT_QUERY, CONTAINER_NAME);
        }
    }
}
