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
        private readonly IFieldConfigBL _fieldConfigBL;
        public DocumentBL(ICosmosDBService cosmosDBService,IApiHeaders apiHeaders,IFieldConfigBL fieldConfigBL)
        {
            _cosmosDBService = cosmosDBService;
            _apiHeaders = apiHeaders;
            _fieldConfigBL = fieldConfigBL;
            PARTITION_KEY = apiHeaders.BPC.ToString();
        }
        public async Task<Document> GetDocumentDataById(string Id)
        {
           return await _cosmosDBService.GetItemAsync<Document>(Id, CONTAINER_NAME, PARTITION_KEY);
        }

        public async Task SaveDocumentData(Document document)
        {
            document.PartitionKey = _apiHeaders.BPC.ToString();
            if (string.IsNullOrEmpty(document.Id))
            {
                document.Id = System.Guid.NewGuid().ToString();
                await _cosmosDBService.AddItemAsync(document, CONTAINER_NAME);
            }
            else
            {
                await _cosmosDBService.UpdateItemAsync(document.Id, document, CONTAINER_NAME, PARTITION_KEY);
            }
        }

        public async Task UpdateDocumentData(Document document)
        {
           await  _cosmosDBService.UpdateItemAsync(document.Id, document, CONTAINER_NAME, PARTITION_KEY);
        }
        public async Task<List<ManageDocumentVIewModel>> GetAllDocuments()
        {
            FieldConfig fieldConfig = await _fieldConfigBL.GetFieldConfiguration("FieldConfig-" + _apiHeaders.BPC.ToString());
            IEnumerable<Document> documents = await _cosmosDBService.GetItemsAsync<Document>(SELECT_QUERY, CONTAINER_NAME);
            return MapColumns(fieldConfig,  documents);
            
        }
        private List<ManageDocumentVIewModel> MapColumns(FieldConfig fieldConfig,  IEnumerable<Document> documents)
        {
            List<ManageDocumentVIewModel> manageDocumentVIewModel = new List<ManageDocumentVIewModel>();
            ManageDocumentVIewModel viewModel = null;
            foreach (Document document in documents)
            {
                viewModel = new ManageDocumentVIewModel();
                viewModel.DocumentType = new FieldViewModel()
                {
                    DisplayName = fieldConfig.DocumentType.Name,
                    Value = document.DocumentType
                };
                viewModel.DocumentName = new FieldViewModel()
                {
                    DisplayName = fieldConfig.DocumentName.Name,
                    Value = document.DocumentName
                };
                viewModel.Category = new FieldViewModel()
                {
                    DisplayName = fieldConfig.Category.Name,
                    Value = document.Category
                };
                viewModel.Region = new FieldViewModel()
                {
                    DisplayName = fieldConfig.Region.Name,
                    Value = document.Region
                };
                viewModel.ItemName = new FieldViewModel()
                {
                    DisplayName = fieldConfig.ItemName.Name,
                    Value = document.ItemName
                };
                viewModel.BusinessUnit = new FieldViewModel()
                {
                    DisplayName = fieldConfig.BusinessUnit.Name,
                    Value = document.BusinessUnit
                };
                viewModel.Id = new FieldViewModel()
                {
                    DisplayName ="id",
                    Value = document.Id
                };
                manageDocumentVIewModel.Add(viewModel);
            }
            return manageDocumentVIewModel;
        }
    }
}
