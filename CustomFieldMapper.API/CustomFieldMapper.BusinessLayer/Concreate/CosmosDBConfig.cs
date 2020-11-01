using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.BusinessLayer.Concreate
{
    public class CosmosDBConfig : ICosmosDBConfig
    {
        public string AcountName { get ; set ; }
        public string Key { get ; set ; }
    }
}
