using Newtonsoft.Json;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class Document: BaseCosmosDBEntity
    {
        public Document()
        {
            
        }
        [JsonProperty(PropertyName = "documentType")]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "documentName")]
        public string DocumentName { get; set; }

        [JsonProperty(PropertyName = "itemName")]
        public string ItemName { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "businessUnit")]
        public string BusinessUnit { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
    }
}
