using Newtonsoft.Json;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class FieldConfig
    {
        [JsonProperty(PropertyName = "documentType")]
        public FieldConfig DocumentType { get; set; }

        [JsonProperty(PropertyName = "documentName")]
        public FieldConfig DocumentName { get; set; }

        [JsonProperty(PropertyName = "itemName")]
        public FieldConfig ItemName { get; set; }

        [JsonProperty(PropertyName = "category")]
        public FieldConfig Category { get; set; }

        [JsonProperty(PropertyName = "businessUnit")]
        public FieldConfig BusinessUnit { get; set; }

        [JsonProperty(PropertyName = "region")]
        public FieldConfig Region { get; set; }
    }
}
