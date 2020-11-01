using SmartFieldMapper.BusinessLayer.Concreate;
using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldMapper.BusinessLayer.Interfaces
{
    public interface IEntityConfigurationBL
    {
        Task<IEnumerable<EntityConfig>> GetEntityConfigList();
        Task SaveEntityConfig(EntityConfig entityConfig);
        Task UpdateEntityConfig(UpdateEntityConfigRequest updateEntityConfigRequest);
    }
}
