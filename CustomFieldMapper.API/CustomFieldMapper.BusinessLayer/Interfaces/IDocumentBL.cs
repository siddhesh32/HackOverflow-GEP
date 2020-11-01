using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Interfaces
{
    public interface IDocumentBL
    {
        Task<Document> GetDocumentDataById(string Id);
        Task SaveDocumentData(Document form);
        Task UpdateDocumentData(Document document);
        Task<IEnumerable<Document>> GetAllDocuments();
        
    }
}
