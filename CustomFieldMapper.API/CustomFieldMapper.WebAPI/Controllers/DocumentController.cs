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
    /// <summary>
    /// Document Controller
    /// </summary>
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentBL _documentBL;
        private readonly IFieldConfigBL _fieldConfigBL;
        private readonly IApiHeaders _apiHeaders;
        /// <summary>
        /// Document Controller
        /// </summary>
        /// <param name="documentBL"></param>
        /// <param name="fieldConfigBL"></param>
        /// <param name="apiHeaders"></param>
        public DocumentController(IDocumentBL documentBL, IFieldConfigBL fieldConfigBL,IApiHeaders apiHeaders)
        {
            _documentBL = documentBL;
            _fieldConfigBL = fieldConfigBL;
            _apiHeaders = apiHeaders;
        }
        /// <summary>
        /// Save Document
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/SaveDocument")]
        public async Task<ActionResult> SaveDocument(Document form)
        {
            await _documentBL.SaveDocumentData(form);
            return Ok();
        }
        /// <summary>
        /// Get All Documents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAllDocuments")]
        public async Task<ActionResult> GetAllDocuments()
        {
           return Ok(await _documentBL.GetAllDocuments());
           
        }
        /// <summary>
        /// Get All Documents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetDocument")]
        public async Task<ActionResult> GetDocument(string Id)
        {
           Document document = await _documentBL.GetDocumentDataById(Id);
            FieldConfig fieldConfig = await _fieldConfigBL.GetFieldConfiguration("FieldConfig-" + _apiHeaders.BPC.ToString()); ;
           DocumentViewModel documentViewModel = new DocumentViewModel()
           {
               Data = document,
               Config = fieldConfig
           };
           return Ok(documentViewModel);
        }
        /// <summary>
        /// UpdateDocumentData
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/UpdateDocumentData")]
        public async Task<ActionResult> UpdateDocumentData(Document form)
        {
            await _documentBL.UpdateDocumentData(form);
            return Ok();
        }
    }
}