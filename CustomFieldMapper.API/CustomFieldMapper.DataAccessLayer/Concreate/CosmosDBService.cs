using Microsoft.Azure.Cosmos;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.DataAccessLayer.Concreate
{
    public class CosmosDBService: ICosmosDBService
    {
        private Container _container;

        public CosmosClient dbClient { get ; set; }
        public DatabaseResponse database { get; set; }

        public async Task AddItemAsync<T>(T item,string containerName)
        {
            try
            {
                this._container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/partitionkey");
                var response = await this._container.CreateItemAsync<T>(item);
            }
            catch(Exception ex)
            {

            }
        }
        public async Task DeleteItemAsync<T>(string id, string containerName, string partitionKey)
        {
            this._container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/partitionkey");
            await this._container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<T> GetItemAsync<T>(string id, string containerName, string partitionKey)
        {
            try
            {
                this._container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/partitionkey");
                ItemResponse<T> response = await this._container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return default(T);
                }
                else
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string queryString,string containerName)
        {
            this._container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/partitionkey");
            var query = this._container.GetItemQueryIterator<dynamic>(new QueryDefinition(queryString));
            List<T> results = new List<T>();
            using (FeedIterator<T> resultSetIterator = _container.GetItemQueryIterator<T>(
               queryString
               ))
            {
                while (resultSetIterator.HasMoreResults)
                {
                    FeedResponse<T> response = await resultSetIterator.ReadNextAsync();
                    results.AddRange(response);
                }
            }
            return results;
        }

        public async Task UpdateItemAsync<T>(string id, T item, string containerName,string partitionKey)
        {
            this._container = await database.Database.CreateContainerIfNotExistsAsync(containerName, "/partitionkey");
            await this._container.UpsertItemAsync<T>(item, new PartitionKey(partitionKey));
        }

    }

}
