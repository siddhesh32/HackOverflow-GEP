using Newtonsoft.Json;
using System;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class FieldConfig: BaseCosmosDBEntity
    {
        public FieldConfig()
        {
            Id = Guid.NewGuid().ToString();
        }
        [JsonProperty(PropertyName = "documentType")]
        public ColumnConfig DocumentType { get; set; }

        [JsonProperty(PropertyName = "documentName")]
        public ColumnConfig DocumentName { get; set; }

        [JsonProperty(PropertyName = "itemName")]
        public ColumnConfig ItemName { get; set; }

        [JsonProperty(PropertyName = "category")]
        public ColumnConfig Category { get; set; }

        [JsonProperty(PropertyName = "businessUnit")]
        public ColumnConfig BusinessUnit { get; set; }

        [JsonProperty(PropertyName = "region")]
        public ColumnConfig Region { get; set; }
    }
}
