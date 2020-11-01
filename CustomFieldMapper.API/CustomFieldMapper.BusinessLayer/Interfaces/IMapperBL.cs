using SmartFieldMapper.BusinessLayer.Entities;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Interfaces
{
    public interface IMapperBL
    {
        Task<Document> GetAllData();
    }
}
