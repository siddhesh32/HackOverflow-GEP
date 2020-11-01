using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Controllers
{
    [ApiController]
    public class EntityConfigController : ControllerBase
    {
        private readonly IEntityConfigurationBL _entityConfigurationBL;
        public EntityConfigController(IEntityConfigurationBL entityConfigurationBL)
        {
            _entityConfigurationBL = entityConfigurationBL;
        }
        [HttpGet]
        [Route("api/GetAllEntityConfiguration")]
        public async Task<ActionResult> GetAllEntityConfiguration()
        {
            IEnumerable<EntityConfig> entityConfigs = await _entityConfigurationBL.GetEntityConfigList();
            return Ok(entityConfigs);
        }
        [HttpPost]
        [Route("api/SaveEntityConfiguration")]
        public async Task<ActionResult> SaveEntityConfiguration(EntityConfig entityConfig)
        {
            await _entityConfigurationBL.SaveEntityConfig(entityConfig);
            return Ok();
        }
        [HttpPost]
        [Route("api/UpdateEntityConfiguration")]
        public async Task<ActionResult> UpdateEntityConfiguration(string Id,EntityConfig entityConfig)
        {
            await _entityConfigurationBL.UpdateEntityConfig(Id, entityConfig);
            return Ok();
        }
    }
}