using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace SmartFieldMapper.WebAPI.Controllers
{
    /// <summary>
    /// Template Controller
    /// </summary>
    [ApiController]
    public class TemplateController : ControllerBase
    {
        /// <summary>
        /// Template Controller
        /// </summary>
        private readonly ITemplateBL _templateBL;
        /// <summary>
        /// Template Controller
        /// </summary>
        /// <param name="templateBL"></param>
        public TemplateController(ITemplateBL templateBL)
        {
            _templateBL = templateBL;
        }
        /// <summary>
        /// Get Mapping TemplateId By Id
        /// </summary>
        /// <param name="TemplateId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetMappingTemplateIdById")]
        public ActionResult GetMappingTemplateIdById(string TemplateId)
        {
            return Ok(_templateBL.GetTemplateById(TemplateId));
        }
    }
}