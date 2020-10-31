using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.DataAccessLayer.Interfaces
{
    public interface ICosmosDBService
    {
        Task AddItemAsync(object item);
        Task DeleteItemAsync(string id);
        Task<dynamic> GetItemAsync(string id);
        Task<IEnumerable<dynamic>> GetItemsAsync(string queryString);
        Task UpdateItemAsync(string id, dynamic item);
    }
}
