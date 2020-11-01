using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer.Interfaces
{
    public interface IApiHeaders
    {
        long BPC { get; set; }
        string DocumentType { get; set; }
    }
}
