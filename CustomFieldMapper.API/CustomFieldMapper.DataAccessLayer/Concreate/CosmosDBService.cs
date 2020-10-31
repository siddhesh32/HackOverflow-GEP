using Microsoft.Azure.Cosmos;
using SmartFieldMapper.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.DataAccessLayer.Concreate
{
    public class CosmosDBService: ICosmosDBService
    {
        private Container _container;
        public CosmosDBService(CosmosClient dbClient,string databaseName,string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task AddItemAsync(dynamic item)
        {
            await this._container.CreateItemAsync<dynamic>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync(string id)
        {
            await this._container.DeleteItemAsync<dynamic>(id, new PartitionKey(id));
        }

        public async Task<dynamic> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<dynamic> response = await this._container.ReadItemAsync<dynamic>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<dynamic>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<dynamic>(new QueryDefinition(queryString));
            List<dynamic> results = new List<dynamic>();
            using (FeedIterator<dynamic> resultSetIterator = _container.GetItemQueryIterator<dynamic>(
               queryString
               ))
            {
                while (resultSetIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> response = await resultSetIterator.ReadNextAsync();
                    results.AddRange(response);
                }
            }
            return results;
        }

        public async Task UpdateItemAsync(string id, dynamic item)
        {
            await this._container.UpsertItemAsync<dynamic>(item, new PartitionKey(id));
        }
    }
}
