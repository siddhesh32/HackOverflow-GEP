using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Entities.Request
{
    public class UpdateDocumentRequest
    {
        public string Id { get; set; }
        public Document form { get; set; }
    }
}
