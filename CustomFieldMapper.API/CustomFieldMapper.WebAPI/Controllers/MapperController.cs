using Microsoft.AspNetCore.Mvc;
using SmartFieldMapper.BusinessLayer.Interfaces;

namespace CustomFieldMapper.WebAPI.Controllers
{
    [ApiController]
    public class MapperController : ControllerBase
    {
        private readonly IMapperBL _mapperBL;
        public MapperController(IMapperBL mapperBL)
        {
            _mapperBL = mapperBL;
        }
        [Route("GetData")]
        public ActionResult GetData()
        {
            return Ok(_mapperBL.GetAllData());
        }
    }
}