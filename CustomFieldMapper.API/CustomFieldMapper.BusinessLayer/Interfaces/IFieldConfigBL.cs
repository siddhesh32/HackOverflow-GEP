using SmartFieldMapper.BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Interfaces
{
    public interface IFieldConfigBL
    {
        Task<FieldConfig> GetFieldConfiguration(string Id);
        void SaveFieldConfiguration(FieldConfig fieldConfig);
        void UpdateFieldConfiguration(string Id ,FieldConfig fieldConfig);
    }
}
