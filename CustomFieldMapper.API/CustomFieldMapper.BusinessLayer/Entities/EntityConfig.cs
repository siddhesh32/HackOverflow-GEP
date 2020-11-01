
namespace SmartFieldMapper.BusinessLayer.Entities
{
    public class EntityConfig: BaseCosmosDBEntity
    {
        public string EntityName { get; set; }
        public string DisplayName { get; set; }
        public string DBFieldName { get; set; }
    }
}
