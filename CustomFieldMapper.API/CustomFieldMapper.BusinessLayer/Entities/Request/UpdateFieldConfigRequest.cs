using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Entities.Request
{
    public class UpdateFieldConfigRequest
    {
        public string Id { get; set; }
        public FieldConfig fieldConfig { get; set; }
    }
}
