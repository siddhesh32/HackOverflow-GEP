using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace CustomFieldMapper.WebAPI.Controllers
{
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly IMapperBL _mapperBL;
        private readonly ITemplateBL _templateBL;
        public MapperController(IMapperBL mapperBL,ITemplateBL templateBL)
        {
            _mapperBL = mapperBL;
            _templateBL = templateBL;
        }
        [HttpGet]
        [Route("api/GetData")]
        public ActionResult GetData(string TemplateId)
        {
            object template = _templateBL.GetTemplateById(TemplateId);
            return Ok(_mapperBL.GetAllData());
        }
    }
}