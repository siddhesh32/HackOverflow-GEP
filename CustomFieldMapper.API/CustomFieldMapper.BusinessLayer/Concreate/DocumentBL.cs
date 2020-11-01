using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Interfaces;
using SmartFieldMapper.DataAccessLayer.Concreate;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class DocumentBL : IDocumentBL
    {
        ICosmosDBService _cosmosDBService;
        public DocumentBL(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }
        public async Task<Document> GetDocumentDataById(string Id)
        {
           return await _cosmosDBService.GetItemAsync<Document>(Id);
        }

        public async Task SaveDocumentData(Document form)
        {
           await _cosmosDBService.AddItemAsync(form);
        }

        public async Task UpdateDocumentData(string Id, Document form)
        {
           await  _cosmosDBService.UpdateItemAsync<Document>(Id, form);
        }
        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            return await _cosmosDBService.GetItemsAsync<Document>("", "", "");
        }
    }
}
