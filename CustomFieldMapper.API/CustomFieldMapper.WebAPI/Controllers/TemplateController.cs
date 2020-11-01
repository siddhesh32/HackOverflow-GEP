using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Controllers
{
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateBL _templateBL;
        public TemplateController(ITemplateBL templateBL)
        {
            _templateBL = templateBL;
        }
        [HttpGet]
        [Route("api/GetMappingTemplateIdById")]
        public ActionResult GetMappingTemplateIdById(string TemplateId)
        {
            return Ok(_templateBL.GetTemplateById(TemplateId));
        }
    }
}