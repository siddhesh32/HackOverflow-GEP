using Newtonsoft.Json;

namespace SmartFieldMapper.BusinessLayer.Entities
{
    public abstract class BaseCosmosDBEntity
    {
        /// <summary>
        /// Gets or sets the identifier. Property value represent the Claim Id.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the partition key.
        /// </summary>
        /// <value>
        /// The partition key.
        /// </value>
        [JsonProperty("partitionkey")]
        public string PartitionKey { get; set; }
    }
}
