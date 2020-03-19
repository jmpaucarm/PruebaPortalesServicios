using OpenDEVCore.Api.Services;
using Core.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenDEVCore.Configuration.Dto;
using System;
using Core.Mvc;

namespace OpenDEVCore.Api.Controllers
{
    /// <summary>
    /// Controlador ApiWategay de Configuration
    /// </summary>
    public class ConfigurationController : BaseController
    {
        private readonly IConfigurationService _configurationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Controlador de Configuration
        /// </summary>
        /// <param name="busPublisher"></param>
        /// <param name="configurationService"></param>
        /// <param name="httpContextAccessor"></param>
        public ConfigurationController(IBusPublisher busPublisher,
            IConfigurationService configurationService, IHttpContextAccessor httpContextAccessor) : base(busPublisher)
        {
            _configurationService = configurationService;
            _httpContextAccessor = httpContextAccessor;
            _configurationService.jsonSession = SessionContext.GetJsonSession();
        }
        #region catalogos
        /// <summary>
        /// Función que obtiene lista de catálogo/detalle en base a códigos
        /// </summary>
        /// <param name="query">"codigo1,codigo2"</param>
        /// <param name="idInstitution">Parámetro que toma de la sesión de la interfaz</param>
        /// <returns>Lista de catálogos</returns>
        [AllowAnonymous]
        [HttpGet("getcatalogsbycodes")]
        public async Task<IActionResult> GetCatalogsByCodes([FromQuery] string query, [FromQuery] int idInstitution)
             => Single(await _configurationService.GetCatalogsByCodes(query, idInstitution));

        /// <summary>
        /// Consulta de catálogo por código 
        /// </summary>
        /// <param name="query">Código de catálogo</param>
        /// <param name="idInstitution">id de la institución del catálogo</param>
        /// <returns>Dto catálogo/detalle</returns>
        [AllowAnonymous]
        [HttpGet("getcataloguebycode")]
        public async Task<IActionResult> GetCatalogueByCode([FromQuery] string query, [FromQuery] int idInstitution)
             => Single(await _configurationService.GetCatalogueByCode(query, idInstitution));

        /// <summary>
        /// Consulta de catálogo por id
        /// </summary>
        /// <param name="id">id del catálogo</param>
        /// <param name="idInstitution">id de la institución</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getcataloguebyid")]
        public async Task<IActionResult> GetCatalogueById([FromQuery] int id, [FromQuery] int idInstitution)
             => Single(await _configurationService.GetCatalogueById(id, idInstitution));

        /// <summary>
        /// Consultar todos los catálogos
        /// </summary>
        /// <returns>Lista de todos los catálogos maestro/detalle</returns>
        [AllowAnonymous]
        [HttpGet("getallcatalogs")]
        public async Task<IActionResult> GetAllCatalogs()
            => Single(await _configurationService.GetAllCatalogs());

        /// <summary>
        /// Insertar nuevo catálogo 
        /// </summary>
        /// <param name="ctlg">Dto con el objeto ctlgo a insertar</param>
        /// <param name="idInstitution">id de la institución</param>
        /// <returns>Id del nuevo catalogo</returns>
        [AllowAnonymous]
        [HttpPost("addcatalogue")]
        public async Task<IActionResult> Add(AddCatalogueDto ctlg, [FromQuery] int idInstitution) => 
        Single(await _configurationService.PostAsync(ctlg));

        /// <summary>
        /// Editar catálogo
        /// </summary>
        /// <param name="ctlg">Dto del catálogo</param>
        /// <returns>True si la actualización fué ok</returns>
        [AllowAnonymous]
        [HttpPost("editcatalogue")]
        public async Task<IActionResult> Edit(EditCatalogueDto ctlg) =>
            Single(await _configurationService.PostAsync(ctlg));

        /// <summary>
        /// Función que valida si un codigo de catálogo existe o no existe
        /// </summary>
        /// <param name="code">Código del catálogo</param>
        /// <param name="idInstitution">Id de la institución</param>
        /// <returns>True/false</returns>
        [AllowAnonymous]
        [HttpGet("findcataloguebycode")]
        public async Task<IActionResult> FindCatalogueByCode([FromQuery] string code, [FromQuery] int idInstitution)
    => Single(await _configurationService.FindCatalogueByCode(code, idInstitution));


        #endregion

        #region INSTITUTION
        /// <summary>
        /// Busca si existe o no una institución
        /// </summary>
        /// <param name="ruc">Ruc de la institución a buscar</param>
        /// <returns>true / false</returns>
        [AllowAnonymous]
        [HttpGet("findinstitutionbyruc")]
        public async Task<IActionResult> FindInstitutionByRuc([FromQuery] string ruc)
                => Single(await _configurationService.FindInstitutionByRuc(ruc));

        /// <summary>
        /// Consultar una institución por id
        /// </summary>
        /// <param name="id">Id de la institución</param>
        /// <returns>Dto con el registro de la institución</returns>
        [AllowAnonymous]
        [HttpGet("getinstitutionbyid")]
        public async Task<IActionResult> GetInstitutionById([FromQuery] int id)
             => Single(await _configurationService.GetInstitutionById(id));

        /// <summary>
        /// Consultar una institución por ruc
        /// </summary>
        /// <param name="code">Ruc de la institución</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getinstitutionbycode")]
        public async Task<IActionResult> GetInstitutionByCode([FromQuery] string code)
           => Single(await _configurationService.GetInstitutionByCode(code));


        /// <summary>
        /// Consulta de todas las instituciones
        /// </summary>
        /// <param name="onlyActive">True = consulta solo las activas, False= trae todas</param>
        /// <param name="onlyInstitution">True=consulta solo las Instituciones, false= consuta las instituciones con sus oficinas</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getallinstitutions")]
        public async Task<IActionResult> Getallinstitutions([FromQuery] bool onlyActive, [FromQuery] bool onlyInstitution)
            => Single(await _configurationService.GetAllInstitutions(onlyActive, onlyInstitution));

        /// <summary>
        /// Inserta una nueva institución
        /// </summary>
        /// <param name="institution"> Dto con el objeto institución/oficina</param>
        /// <returns>Id de la nueva institución</returns>
        [AllowAnonymous]
        [HttpPost("addinstitution")]
        public async Task<IActionResult> Add(AddInstitutionDto institution) =>
               Single(await _configurationService.PostAsync(institution));

        /// <summary>
        /// Editar una institución
        /// </summary>
        /// <param name="institution">Dto con el ojeto institución/oficina</param>
        /// <returns>True si la trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editinstitution")]
        public async Task<IActionResult> Edit(EditInstitutionDto institution) =>
            Single(await _configurationService.PostAsync(institution));
        #endregion

        #region PARAMETER
        /// <summary>
        /// Consultar parámetro por Id
        /// </summary>
        /// <param name="id">I del parámetro</param>
        /// <returns>Dto del parámetro consultado</returns>
        [AllowAnonymous]
        [HttpGet("getparameterbyid")]
        public async Task<IActionResult> GetParameterById([FromQuery] int id)
             => Single(await _configurationService.GetParameterById(id));

        /// <summary>
        /// Consulta si exise o no un parámetro
        /// </summary>
        /// <param name="code">Código del parámetro</param>
        /// <returns>True= existe, False = No exite</returns>
        [AllowAnonymous]
        [HttpGet("findparameter")]
        public async Task<IActionResult> FindParameter([FromQuery] string code)
         => Single(await _configurationService.FindParameter(code));

        /// <summary>
        /// Consulta de parámetro por código
        /// </summary>
        /// <param name="code">Código del parámetro</param>
        /// <returns>Dto con el objeto del parámetro</returns>
        [AllowAnonymous]
        [HttpGet("getparameterbycode")]
        public async Task<IActionResult> GetParameterByCode([FromQuery] string code)
           => Single(await _configurationService.GetParameterByCode(code));

        /// <summary>
        /// Consultar todos los parámetros
        /// </summary>
        /// <returns>Lista de dtos de registros de parámetros</returns>
        [AllowAnonymous]
        [HttpGet("getallparameters")]
        public async Task<IActionResult> GetallParameters()
            => Single(await _configurationService.GetAllParameters());

        /// <summary>
        /// Insertar un nuevo parámetro
        /// </summary>
        /// <param name="parameter">Dto con el objeto parámetro </param>
        /// <returns>Id del nuevo parámetro</returns>
        [AllowAnonymous]
        [HttpPost("addparameter")]
        public async Task<IActionResult> Add(AddParameterDto parameter) =>
               Single(await _configurationService.PostAsync(parameter));

        /// <summary>
        /// Editar parámetro
        /// </summary>
        /// <param name="parameter">Dto con el objeto parámetro</param>
        /// <returns>True si  la trx ok</returns>
        [AllowAnonymous]
        [HttpPost("editparameter")]
        public async Task<IActionResult> Edit(EditParameterDto parameter) =>
            Single(await _configurationService.PostAsync(parameter));


        #endregion



        #region HOLIDAY
        /// <summary>
        /// Consultar dias feriado por id
        /// </summary>
        /// <param name="id">id del día feriado</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getholidaybyid")]
        public async Task<IActionResult> GetHolidayById([FromQuery] int id)
             => Single(await _configurationService.GetHolidayById(id));

        /// <summary>
        /// Consultar día feriador por fecha y ubicación geografica
        /// </summary>
        /// <param name="holidaydate">Fecha del día feriado</param>
        /// <param name="idUbication">Id de ubicación geográfica2, Si IdUbicaciongeografica = 0 es feriado nacional</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getholidaybydate")]
        public async Task<IActionResult> GetHolidayBydate([FromQuery] long holidaydate, [FromQuery] int idUbication)
           => Single(await _configurationService.GetHolidayByDate(holidaydate,idUbication));

        /// <summary>
        /// Buscar si existe o no una fecha 
        /// </summary>
        /// <param name="holidaydate">Fecha del feriado</param>
        /// <param name="idUbication">id de la ubicacion geografica 2</param>
        /// <returns>true/false</returns>
        [AllowAnonymous]
        [HttpGet("findholiday")]
        public async Task<IActionResult> FindHolidayBydate([FromQuery] long holidaydate, [FromQuery] int idUbication)
           => Single(await _configurationService.FindHolidayByDate(holidaydate, idUbication));

        /// <summary>
        /// Consultar todos los dias feriados
        /// </summary>
        /// <returns>Lista de Dto de dias feriados</returns>
        [AllowAnonymous]
        [HttpGet("getallholidays")]
        public async Task<IActionResult> GetAllHolidays()
            => Single(await _configurationService.GetAllHolidays());

        /// <summary>
        /// Insertar día feriado
        /// </summary>
        /// <param name="holiday">Dto del feriado</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("addholiday")]
        public async Task<IActionResult> Add(AddHolidayDto holiday) =>
               Single(await _configurationService.PostAsync(holiday));

        /// <summary>
        /// Editar día feriado
        /// </summary>
        /// <param name="holiday">Dto del día feriado</param>
        /// <returns>True en el caso que la trx termine ok</returns>
        [AllowAnonymous]
        [HttpPost("editholiday")]
        public async Task<IActionResult> Edit(EditHolidayDto holiday) =>
            Single(await _configurationService.PostAsync(holiday));

        #endregion

        #region UBICACIONGOGRAFICA1
        /// <summary>
        /// Consulta todas las UG1
        /// </summary>
        /// <returns>Lista de Dto de UG1</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation1")]
        public async Task<IActionResult> GetAllLocation1()
         => Single(await _configurationService.GetAllLocation1());

        /// <summary>
        /// Consulta  UG1 por código
        /// </summary>
        /// <param name="code">Código de UG1</param>
        /// <returns>Dto Ug1</returns>
        [AllowAnonymous]
        [HttpGet("getbycodelocation1")]
        public async Task<IActionResult> GetByCodeLocation1([FromQuery] string code)
             => Single(await _configurationService.GetByCodeLocation1(code));

        /// <summary>
        /// Consulta  de UG1 por Id
        /// </summary>
        /// <param name="id">Id de UG1</param>
        /// <returns>Dto Ug1 </returns>
        [AllowAnonymous]
        [HttpGet("getbyidlocation1")]
        public async Task<IActionResult> GetByIdLocation1([FromQuery] int id)
           => Single(await _configurationService.GetByIdLocation1(id));

        /// <summary>
        /// Insertar UG1
        /// </summary>
        /// <param name="ubi">Dto Ug1</param>
        /// <returns>Id de la Ug1 insertada</returns>
        [AllowAnonymous]
        [HttpPost("addlocation1")]
        public async Task<IActionResult> Add(AddGeographicLocation1Dto ubi) =>
               Single(await _configurationService.PostAsync(ubi));

        /// <summary>
        /// Editar UG1
        /// </summary>
        /// <param name="ubi">Dto UG1</param>
        /// <returns>True en el caso que la trx termine ok</returns>
        [AllowAnonymous]
        [HttpPost("editlocation1")]
        public async Task<IActionResult> Edit(EditGeographicLocation1Dto ubi) =>
            Single(await _configurationService.PostAsync(ubi));

        #endregion

        #region UBICACIONGOGRAFICA2
        /// <summary>
        /// Consultar todos las UG2 de una UG1
        /// </summary>
        /// <param name="id">id de Ug1</param>
        /// <returns>Lista Dto de UG2</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation2")]
        public async Task<IActionResult> GetAllLocation2([FromQuery] int id)
         => Single(await _configurationService.GetAllLocation2(id));

        /// <summary>
        /// Consultar todos las UG2 de una UG1
        /// </summary>
        /// <param name="code">código de Ug1</param>
        /// <returns>Lista Dto de UG2</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation2ByCode")]
        public async Task<IActionResult> GetAllLocation2ByCode([FromQuery] string code)
         => Single(await _configurationService.GetAllLocation2ByCode(code));

        /// <summary>
        /// Consulta todos los registros de UG2 a nivel nacional
        /// </summary>
        /// <returns>Lista de dtos de UG2 nacional</returns>
        [AllowAnonymous]
        [HttpGet("getallonlylocation2")]
        public async Task<IActionResult> GetOnlyAllLocation2()
        => Single(await _configurationService.GetAllOnlyLocation2());


        /// <summary>
        /// Consulta UG2 por código
        /// </summary>
        /// <param name="code">Código Ug2</param>
        /// <returns>Dto de UG2</returns>
        [AllowAnonymous]
        [HttpGet("getbycodelocation2")]
        public async Task<IActionResult> GetByCodeLocation2([FromQuery] string code)
             => Single(await _configurationService.GetByCodeLocation2(code));

        /// <summary>
        /// Consulta UG2 por id
        /// </summary>
        /// <param name="id">Id Ug2</param>
        /// <returns>Dto de UG2</returns>
        [AllowAnonymous]
        [HttpGet("getbyidlocation2")]
        public async Task<IActionResult> GetByIdLocation2([FromQuery] int id)
           => Single(await _configurationService.GetByIdLocation2(id));

        /// <summary>
        /// Insertar UB"
        /// </summary>
        /// <param name="ubi">Dto de UG2</param>
        /// <returns>Id del nuevo registro de UG2</returns>
        [AllowAnonymous]
        [HttpPost("addlocation2")]
        public async Task<IActionResult> Add(AddGeographicLocation2Dto ubi) =>
               Single(await _configurationService.PostAsync(ubi));

        /// <summary>
        /// Editar Ug2
        /// </summary>
        /// <param name="ubi">Dto Ug2</param>
        /// <returns>True si trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editlocation2")]
        public async Task<IActionResult> Edit(EditGeographicLocation2Dto ubi) =>
            Single(await _configurationService.PostAsync(ubi));

        #endregion


        #region UBICACIONGOGRAFICA3

        /// <summary>
        /// Consulta de todas las UG3 por Id
        /// </summary>
        /// <param name="id">Id UG3</param>
        /// <returns>Lista dto´s de UG3</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation3")]
        public async Task<IActionResult> GetAllLocation3([FromQuery] int id)
         => Single(await _configurationService.GetAllLocation3(id));

        /// <summary>
        /// Consultar todos las UG3 de una UG2
        /// </summary>
        /// <param name="code">código de Ug2</param>
        /// <returns>Lista Dto de UG3</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation3ByCode")]
        public async Task<IActionResult> GetAllLocation3ByCode([FromQuery] string code)
         => Single(await _configurationService.GetAllLocation3ByCode(code));

        /// <summary>
        /// Consulta UG3 por código
        /// </summary>
        /// <param name="code">Codigo UG3</param>
        /// <returns>Dto UG3</returns>
        [AllowAnonymous]
        [HttpGet("getbycodelocation3")]
        public async Task<IActionResult> GetByCodeLocation3([FromQuery] string code)
             => Single(await _configurationService.GetByCodeLocation3(code));

        /// <summary>
        /// Consulta de UG3 por id
        /// </summary>
        /// <param name="id">Id UG3</param>
        /// <returns>Dto UG3</returns>
        [AllowAnonymous]
        [HttpGet("getbyidlocation3")]
        public async Task<IActionResult> GetByIdLocation3([FromQuery] int id)
           => Single(await _configurationService.GetByIdLocation3(id));

        /// <summary>
        /// Insertar UG3
        /// </summary>
        /// <param name="ubi">Dto Ug3</param>
        /// <returns>id de la nueva UG3</returns>
        [AllowAnonymous]
        [HttpPost("addlocation3")]
        public async Task<IActionResult> Add(AddGeographicLocation3Dto ubi) =>
               Single(await _configurationService.PostAsync(ubi));

        /// <summary>
        /// Editar UG3
        /// </summary>
        /// <param name="ubi">Dto Ug3</param>
        /// <returns>True si la trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editlocation3")]
        public async Task<IActionResult> Edit(EditGeographicLocation3Dto ubi) =>
            Single(await _configurationService.PostAsync(ubi));

        #endregion

        #region UBICACIONGOGRAFICA4
        /// <summary>
        /// Consultar todos los registro de UG4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("getalllocation4")]
        public async Task<IActionResult> GetAllLocation4([FromQuery] int id)
         => Single(await _configurationService.GetAllLocation4(id));

        /// <summary>
        /// Consultar todos las UG4 de una UG3
        /// </summary>
        /// <param name="code">código de Ug3</param>
        /// <returns>Lista Dto de UG4</returns>
        [AllowAnonymous]
        [HttpGet("getalllocation4ByCode")]
        public async Task<IActionResult> GetAllLocation4ByCode([FromQuery] string code)
         => Single(await _configurationService.GetAllLocation4ByCode(code));


        /// <summary>
        /// Consultar UG4 por código
        /// </summary>
        /// <param name="code">Código Ug4</param>
        /// <returns>Dto Ug4</returns>
        [AllowAnonymous]
        [HttpGet("getbycodelocation4")]
        public async Task<IActionResult> GetByCodeLocation4([FromQuery] string code)
             => Single(await _configurationService.GetByCodeLocation4(code));

        /// <summary>
        /// Consultar UG4 por id
        /// </summary>
        /// <param name="id">Id UG4</param>
        /// <returns>Dto Ug4</returns>
        [AllowAnonymous]
        [HttpGet("getbyidlocation4")]
        public async Task<IActionResult> GetByIdLocation4([FromQuery] int id)
           => Single(await _configurationService.GetByIdLocation4(id));

        /// <summary>
        /// Insertar UG4
        /// </summary>
        /// <param name="ubi">Dto Ug4</param>
        /// <returns>Id de Ug4 nuevo</returns>
        [AllowAnonymous]
        [HttpPost("addlocation4")]
        public async Task<IActionResult> Add(AddGeographicLocation4Dto ubi) =>
               Single(await _configurationService.PostAsync(ubi));

        /// <summary>
        /// Editar UG4
        /// </summary>
        /// <param name="ubi">Dto Ug4</param>
        /// <returns>True si trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editlocation4")]
        public async Task<IActionResult> Edit(EditGeographicLocation4Dto ubi) =>
            Single(await _configurationService.PostAsync(ubi));

        #endregion

    }
}
