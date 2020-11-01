using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Entities;
using SmartFieldMapper.BusinessLayer.Entities.Request;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Controllers
{
    /// <summary>
    /// FIeld Config Controller
    /// </summary>
    [ApiController]
    public class FIeldConfigController : ControllerBase
    {
        private readonly IFieldConfigBL _fieldConfigBL;
        /// <summary>
        /// FIeld Config Controller constructor
        /// </summary>
        /// <param name="fieldConfigBL"></param>
        public FIeldConfigController(IFieldConfigBL fieldConfigBL)
        {
            _fieldConfigBL = fieldConfigBL;
        }
        /// <summary>
        /// Get Field Configuration
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetFieldConfiguration")]
        public async Task<ActionResult> GetFieldConfiguration(string Id)
        {
            FieldConfig fieldConfig = await _fieldConfigBL.GetFieldConfiguration(Id);
            return Ok(fieldConfig);
        }
        /// <summary>
        /// Save Field Configuration
        /// </summary>
        /// <param name="fieldConfig"></param>
        [HttpPost]
        [Route("api/SaveFieldConfiguration")]
        public void SaveFieldConfiguration(FieldConfig fieldConfig)
        {
            _fieldConfigBL.SaveFieldConfiguration(fieldConfig);
        }
        /// <summary>
        /// Update Field Configuration
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fieldConfig"></param>
        [HttpPost]
        [Route("api/UpdateFieldConfiguration")]
        public void UpdateFieldConfiguration(UpdateFieldConfigRequest updateFieldConfigRequest)
        {
            _fieldConfigBL.UpdateFieldConfiguration(updateFieldConfigRequest);
        }
    }
}