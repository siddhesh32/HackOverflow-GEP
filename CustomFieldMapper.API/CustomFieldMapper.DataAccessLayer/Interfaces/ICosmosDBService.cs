using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.DataAccessLayer.Interfaces
{
    public interface ICosmosDBService
    {
        CosmosClient dbClient { get; set; }
        DatabaseResponse database { get; set; }
        Task AddItemAsync<T>(T item, string containerName);
        Task DeleteItemAsync<T>(string id, string containerName, string partitionKey);
        Task<T> GetItemAsync<T>(string id, string containerName,string partitionKey);
        Task<IEnumerable<T>> GetItemsAsync<T>(string queryString,string containerName);
        Task UpdateItemAsync<T>(string id, T item, string containerName, string partitionKey);
    }
}
