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
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentBL _documentBL;
        public DocumentController(IDocumentBL documentBL)
        {
            _documentBL = documentBL;
        }
        [HttpPost]
        [Route("api/SaveDocument")]
        public async Task<ActionResult> SaveDocument(Document form)
        {
            await _documentBL.SaveDocumentData(form);
            return Ok();
        }
        [HttpGet]
        [Route("api/GetAllDocuments")]
        public async Task<ActionResult> GetAllDocuments()
        {
           return Ok(await _documentBL.GetAllDocuments());
           
        }

    }
}