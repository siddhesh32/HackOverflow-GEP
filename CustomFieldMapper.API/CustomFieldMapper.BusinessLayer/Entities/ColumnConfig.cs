using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class ColumnConfig
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "isItext")]
        public bool IsItext { get; set; }
        [JsonProperty(PropertyName = "iText")]
        public string IText { get; set; }
    }
}
