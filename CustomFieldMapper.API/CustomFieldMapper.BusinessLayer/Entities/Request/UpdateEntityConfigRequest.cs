using SmartFieldMapper.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Entities.Request
{
    public class UpdateEntityConfigRequest
    {
        public string Id { get; set; }
        public EntityConfig entityConfig { get; set; }
    }
}
