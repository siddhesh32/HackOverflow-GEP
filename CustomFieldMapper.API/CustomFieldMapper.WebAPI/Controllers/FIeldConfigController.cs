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
    public class FIeldConfigController : ControllerBase
    {
        public readonly IFieldConfigBL _fieldConfigBL;
        public FIeldConfigController(IFieldConfigBL fieldConfigBL)
        {
            _fieldConfigBL = fieldConfigBL;
        }
        [HttpGet]
        [Route("api/GetFieldConfiguration")]
        public async Task<ActionResult> GetFieldConfiguration(string Id)
        {
            FieldConfig fieldConfig = await _fieldConfigBL.GetFieldConfiguration(Id);
            return Ok(fieldConfig);
        }
        [HttpPost]
        [Route("api/SaveFieldConfiguration")]
        public void SaveFieldConfiguration(FieldConfig fieldConfig)
        {
            _fieldConfigBL.SaveFieldConfiguration(fieldConfig);
        }
        [HttpPost]
        [Route("api/UpdateFieldConfiguration")]
        public void UpdateFieldConfiguration(string Id, FieldConfig fieldConfig)
        {
            _fieldConfigBL.UpdateFieldConfiguration(Id, fieldConfig);
        }
    }
}