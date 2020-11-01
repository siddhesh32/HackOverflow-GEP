using SmartFieldMapper.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFieldMapper.BusinessLayer
{
    public static class Utils
    {
        public static void SetDBProperties(BaseCosmosDBEntity obj,string partitionKey, string Id)
        {
            obj.PartitionKey = partitionKey;
            obj.Id = Id;
        }
    }
}
