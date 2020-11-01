using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFieldMapper.WebAPI
{
    public class SwaggerOption
    {
        /// <summary>
        /// The identifier of JsonRoute.
        /// </summary>
        public string JsonRoute { get; set; }
        /// <summary>
        /// To get Description and Endpoint in list.
        /// </summary>
        public List<SwaggerUIEndpoint> SwaggerUIEndpoints { get; set; }
    }
    /// <summary>
    /// Get details of swagger with Description and Endpoint.
    /// </summary>
    public class SwaggerUIEndpoint
    {
        /// <summary>
        /// The identifier of Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The identifier of Endpoint.
        /// </summary>
        public string Endpoint { get; set; }
    }
}
