using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Controllers
{
    /// <summary>
    /// Entity Config Controller
    /// </summary>
    [ApiController]
    public class EntityConfigController : ControllerBase
    {
        private readonly IEntityConfigurationBL _entityConfigurationBL;
        /// <summary>
        /// Entity Config Controller
        /// </summary>
        /// <param name="entityConfigurationBL"></param>
        public EntityConfigController(IEntityConfigurationBL entityConfigurationBL)
        {
            _entityConfigurationBL = entityConfigurationBL;
        }
        /// <summary>
        /// Get All Entity Configuration
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAllEntityConfiguration")]
        public async Task<ActionResult> GetAllEntityConfiguration()
        {
            IEnumerable<EntityConfig> entityConfigs = await _entityConfigurationBL.GetEntityConfigList();
            return Ok(entityConfigs);
        }
        /// <summary>
        /// Save Entity Configuration
        /// </summary>
        /// <param name="entityConfig"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/SaveEntityConfiguration")]
        public async Task<ActionResult> SaveEntityConfiguration(EntityConfig entityConfig)
        {
            await _entityConfigurationBL.SaveEntityConfig(entityConfig);
            return Ok();
        }
        /// <summary>
        /// Update Entity Configuration
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="updateEntityConfig"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/UpdateEntityConfiguration")]
        public async Task<ActionResult> UpdateEntityConfiguration(UpdateEntityConfigRequest updateEntityConfig)
        {
            await _entityConfigurationBL.UpdateEntityConfig(updateEntityConfig);
            return Ok();
        }
    }
}