using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services;
using OpenDEVCore.DocConfiguration.Dto;
using OpenDEVCore.DocConfiguration.Services.Interfaces;

namespace OpenDevCore.DocConfiguration.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class TypeDocumentController : ControllerBase
    {
        private readonly ITypeDocumentService _typeDocumentService;
        private readonly IFormDataService _formDataService;
        /// <summary>
        /// Constructor for the respective controller
        /// </summary>
        /// <param name="typeDocumentService">Represents the service that manages the dto</param>
        public TypeDocumentController(ITypeDocumentService typeDocumentService, IFormDataService formDataService)
        {
            _typeDocumentService = typeDocumentService;
            _formDataService = formDataService;
        }

        /// <summary>
        /// Obtains all the typeDocuments filtred by difrent params
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="active"></param>
        /// <returns>List<TypeDocumentDto></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]string institution, [FromQuery]bool active)
        {
            var typeDocuemnts = await _typeDocumentService.GetAll(institution, active);
            return Ok(typeDocuemnts);
        }

        [HttpGet("GetAllForm")]
        public async Task<IActionResult> GetAllForm([FromQuery]string institution, [FromQuery]bool isForm)
        {
            var typeDocuemnts = await _typeDocumentService.GetAllForm(institution, isForm);
            return Ok(typeDocuemnts);
        }

        /// <summary>
        /// Add an unexisting type document if the document type alredy exists it returns an exception
        /// </summary>
        /// <param name="typeDocumentDto"></param>
        /// <returns>TypeDocumentDto</returns>

        [HttpPost("Add")]
         public async Task<IActionResult> Add(TypeDocumentDto typeDocumentDto)
        {
            var postedTypeDocuemt = await _typeDocumentService.Add(typeDocumentDto);
            return Ok(postedTypeDocuemt);
        }

        /// <summary>
        /// Obtains the TypeDocumentDto filtred by the given params
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>TypeDocumentDto</returns>
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeDocumentService.GetByCode(code, institution);
            return Ok(typeDocuemnts);
        }

        [HttpPost("GetFormData")]
        public IActionResult GetFormData([FromBody] FormSpDto formSpDto)
        {
            SqlParameter[] sqlParam = new SqlParameter[formSpDto.SpArgs.Count()];
            for (int i = 0; i < formSpDto.SpArgs.Count(); i++)
            {
                sqlParam[i] = new SqlParameter(formSpDto.SpArgs[i].Name, formSpDto.SpArgs[i].Value);
            }    
            
            //string formCode, string institution, string databaseCode, string spName, SqlParameter[] spArgs
            var json = _formDataService.GetFormData(formSpDto.FormCode, formSpDto.Institution, formSpDto.DatabaseCode, formSpDto.SpName, sqlParam);
            return Ok(json);
        }


        /// <summary>
        /// Return true if TypeDocumentDto was found in bd or else if wasn't found
        /// </summary>
        /// <param name="code"></param>
        /// <param name="institution"></param>
        /// <returns>boolean</returns>
        [HttpGet("Find")]
        public async Task<IActionResult> Find([FromQuery]string code, [FromQuery] string institution)
        {
            var typeDocuemnts = await _typeDocumentService.Find(code, institution);
            return Ok(typeDocuemnts);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        /// <param name="codes">list of codes to lookup</param>
        /// <returns>boolean</returns>
        [HttpPut("edit")]
        public async Task<IActionResult> Edit(TypeDocumentDto typeDocumentDto)
        {
            var typeDocuemnts = await _typeDocumentService.Edit(typeDocumentDto);
            return Ok(typeDocuemnts);
        }


        [HttpGet("getconfigurations")]
        public async Task<IActionResult> GetConfigurations([FromQuery]string institution, [FromQuery] string[] codes)
        {
            List<string> lista2 = codes.OfType<string>().ToList();
            var typeDocuments = await _typeDocumentService.GetConfigurations(lista2, institution);
            return Ok(typeDocuments);
        }
    }
}

