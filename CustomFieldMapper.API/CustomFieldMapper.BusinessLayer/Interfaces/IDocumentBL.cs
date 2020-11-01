using SmartFieldMapper.BusinessLayer.Entities;
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
        Task UpdateDocumentData(string Id, Document form);
        Task<IEnumerable<Document>> GetAllDocuments();
        
    }
}
