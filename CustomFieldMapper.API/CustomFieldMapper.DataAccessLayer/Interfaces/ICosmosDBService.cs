using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.DataAccessLayer.Interfaces
{
    public interface ICosmosDBService
    {
        Task AddItemAsync<T>(T item);
        Task DeleteItemAsync<T>(string id);
        Task<T> GetItemAsync<T>(string id);
        Task<IEnumerable<T>> GetItemsAsync<T>(string queryString, string databaseId, string containerName);
        Task UpdateItemAsync<T>(string id, T item);
    }
}
