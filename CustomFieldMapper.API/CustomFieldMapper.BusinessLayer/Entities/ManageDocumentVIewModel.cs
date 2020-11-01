using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class ManageDocumentVIewModel
    {
        public FieldViewModel DocumentType { get; set; }
        public FieldViewModel DocumentName { get; set; }
        public FieldViewModel ItemName { get; set; }
        public FieldViewModel Category { get; set; }
        public FieldViewModel BusinessUnit { get; set; }
        public FieldViewModel Region { get; set; }
        public FieldViewModel Id { get; set; }
    }
}
