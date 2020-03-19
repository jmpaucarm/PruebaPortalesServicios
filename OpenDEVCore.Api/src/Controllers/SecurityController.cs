using OpenDEVCore.Api.Services;
using Core.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;
using Core.General;
using Core.Mvc;
using OpenDEVCore.Security.Messages.Commands;
using Microsoft.AspNetCore.Http;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Queries;

namespace OpenDEVCore.Api.Controllers
{
    /// <summary>
    /// Controlador de Security
    /// </summary>
    public class SecurityController : BaseController
    {
        private readonly ISecurityService _securityService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Constructor de Security
        /// </summary>
        /// <param name="busPublisher"></param>
        /// <param name="securityService"></param>
        /// <param name="httpContextAccessor"></param>
        public SecurityController(IBusPublisher busPublisher,
            ISecurityService securityService, IHttpContextAccessor httpContextAccessor) : base(busPublisher)
        {
            _securityService = securityService;
            _securityService.jsonSession = SessionContext.GetJsonSession();
            _httpContextAccessor = httpContextAccessor;
        }
        #region IDENTITY
        /// <summary>
        /// Autenticación de seguridad
        /// </summary>
        /// <param name="cmnd">Dto de Seguridad</param>
        /// <returns>True /false</returns>
        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserGeneral cmnd)
             => Single(await _securityService.SignInAsync(cmnd));

        /// <summary>
        /// Salir del sistema
        /// </summary>
        /// <param name="cmnd">Dto de desconectar usuario</param>
        /// <returns>True</returns>
        [HttpPut("signout")]
        public async Task<IActionResult> SignOut([FromBody]DisconnectUser cmnd)
        {
            Guid id = new Guid();
            return await SendAsync(cmnd.Bind(c => c.Id, id), resourceId: cmnd.Id, resource: "security");
        }

        /// <summary>
        /// Cambio de password
        /// </summary>
        /// <param name="cmnd">Dto de seguridad</param>
        /// <returns>True</returns>
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(UserGeneral cmnd)
          => Single(await _securityService.ChangePasswordAsync(cmnd));

        /// <summary>
        /// Conecta usuario 
        /// </summary>
        /// <param name="cmnd">Dto de Seguridad</param>
        /// <returns>Token JWT y Session</returns>
        [AllowAnonymous]
        [HttpPost("connect")]
        public async Task<IActionResult> Connect([Body] UserGeneral cmnd)
           => Single(await _securityService.ConnectAsync(cmnd));
        #endregion

        #region USER

        /// <summary>
        /// Editar Usuario
        /// </summary>
        /// <param name="command">Dto de objeto Usuario</param>
        /// <returns>true en el caso que la trx termine ok</returns>
        //[AllowAnonymous]
        [HttpPost("edit")]
        public async Task<IActionResult> Edit(EditUserDto command) => Single(await _securityService.PostAsync(command));
        

        /// <summary>
        /// Insertar nuevo registro de usuario
        /// </summary>
        /// <param name="command">Dto de objeto de usuario</param>
        /// <returns>Id del nuevo registro de Usuario</returns>
        //[AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddUserDto command)
        {
            // PARA PASAR LA SESSION
            return Single(await _securityService.PostAsync(command));
        }

        /// <summary>
        /// Consultar usuario /perfiles
        /// </summary>
        /// <param name="command">Dto general de seguridad</param>
        /// <returns>Usuario con sus perfiles</returns>
        [AllowAnonymous]
        [HttpGet("getuserprofiles")]
        public async Task<IActionResult> GetUserProfiles([FromQuery]UserGeneral command)
           => Single(await _securityService.GetUserProfiles(command));

        /// <summary>
        /// Consultar todos los usuarios
        /// </summary>
        /// <returns>Lista dto de Usuarios</returns>
        //[AllowAnonymous]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
           => Single(await _securityService.GetAllAsync());

        /// <summary>
        /// Consultar usuario por username
        /// </summary>
        /// <param name="query">Dto general de seguridad</param>
        /// <returns>Dto de usuario</returns>
        //[AllowAnonymous]
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery]UserGeneral query)
           => Single(await _securityService.GetAsync(query));


        /// <summary>
        /// Consulta de todos los usuarios
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Lista dtos de todos los usuarios</returns>
        [HttpGet("browseall")]
        public async Task<IActionResult> BrowseAll([FromQuery] BrowseAllUsers query)
          => Collection(await _securityService.BrowseAllAsync(query));


        /// <summary>
        /// Consulta si existe o no un usuario
        /// </summary>
        /// <param name="query">Dto general de seguridad</param>
        /// <returns>True = si encuentra, False = no encuentra</returns>
        //[AllowAnonymous]
        [HttpGet("find")]
        public async Task<IActionResult> Find([FromQuery]UserGeneral query)
           => Single(await _securityService.FindAsync(query));

        /// <summary>
        /// Desbloquear usuario
        /// </summary>
        /// <param name="cmnd">Dto de desbloqueo</param>
        /// <returns>true</returns>
        //[AllowAnonymous]
        [HttpPut("unlock")]
        public async Task<IActionResult> UnLock([FromBody]UnLock cmnd)
        {
            Guid id = new Guid();
            return await SendAsync(cmnd.Bind(c => c.Id, id), resourceId: cmnd.Id, resource: "security");
        }

        /// <summary>
        /// Desconectar usuario
        /// </summary>
        /// <param name="cmnd">Dto de desconección</param>
        /// <returns>true</returns>
        //[AllowAnonymous]
        [HttpPut("disconnect")]
        public async Task<IActionResult> Disconnect([FromBody]DisconnectUser cmnd)
        {
            Guid id = new Guid();
            return await SendAsync(cmnd.Bind(c => c.Id, id), resourceId: cmnd.Id, resource: "security");
        }
        #endregion

        #region Profiles
        /// <summary>
        /// Consultar todos los perfiles
        /// </summary>
        /// <returns></returns>
        // [AllowAnonymous]
        [HttpGet("getallprofiles")]
        public async Task<IActionResult> GetAllProfiles()
           => Single(await _securityService.GetAllProfileAsync());

        /// <summary>
        /// Consultar si un perfil existe o no
        /// </summary>
        /// <param name="code">Código dle perfil</param>
        /// <param name="idInstitution">Id de la institución</param>
        /// <returns>True = si existe, False = no existe</returns>
        [AllowAnonymous]
        [HttpGet("findprofilebycode")]
        public async Task<IActionResult> FindProfileByCode([FromQuery] string code, [FromQuery] int idInstitution)
        => Single(await _securityService.FindProfileByCode(code, idInstitution));

        /// <summary>
        /// Consultar perfil por Id
        /// </summary>
        /// <param name="id">Id del perfil</param>
        /// <param name="institution">Id de la institución</param>
        /// <returns>Dto de perfil</returns>
        [AllowAnonymous]
        [HttpGet("getprofilebyid")]
        public async Task<IActionResult> GetProfileById([FromQuery] int id, [FromQuery] int institution)
          => Single(await _securityService.GetProfileById(id));


        /// <summary>
        /// Consultar perfil por código
        /// </summary>
        /// <param name="code">Código dle perfil</param>
        /// <param name="idInstitution">Id de la institución</param>
        /// <returns>Dto dle perfil</returns>
        [AllowAnonymous]
        [HttpGet("getprofilebycode")]
        public async Task<IActionResult> GetProfileByCode([FromQuery] string code, [FromQuery] int idInstitution)
           => Single(await _securityService.GetProfileByCode(code, idInstitution));

        /// <summary>
        /// Instar un perfil
        /// </summary>
        /// <param name="profile">Dto del perfil</param>
        /// <returns>Id del nuevo perfil</returns>

        [AllowAnonymous]
        [HttpPost("addprofile")]
        public async Task<IActionResult> Add(AddProfileDto profile) => Single(await _securityService.PostAsync(profile));
            
        /// <summary>
        /// Editar perfil
        /// </summary>
        /// <param name="profile">Dto dle perfil</param>
        /// <returns>True si trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editprofile")]
        public async Task<IActionResult> Edit(EditProfileDto profile) =>
            Single(await _securityService.PostAsync(profile));

        #endregion

        #region Menu

        /// <summary>
        /// Cosultar todo el menú
        /// </summary>
        /// <returns>Lista dto de menu</returns>
        [AllowAnonymous]
        [HttpGet("getallmenus")]
        public async Task<IActionResult> GetAllMenus() => Single(await _securityService.GetAllMenusAsync());

        /// <summary>
        /// Consulta de todas las pantallas
        /// </summary>
        /// <returns>Lista dto de todas las pantallas</returns>
        [AllowAnonymous]
        [HttpGet("getallmenuscreens")]
        public async Task<IActionResult> GetAllMenuScreens() => Single(await _securityService.GetAllMenuScreensAsync());

        /// <summary>
        /// Editar menú
        /// </summary>
        /// <param name="menuDto">Dto de menu</param>
        /// <returns>True si la trx termina ok</returns>
        [AllowAnonymous]
        [HttpPost("editmenu")]
        public async Task<IActionResult> EditMenuAsync(MenuDto menuDto) => Single(await _securityService.EditMenuAsync(menuDto));

        /// <summary>
        /// Insertar menu
        /// </summary>
        /// <param name="menuDto">Dto de menú</param>
        /// <returns>Id de nuevo registro de menú</returns>
        [AllowAnonymous]
        [HttpPost("addmenu")]
        public async Task<IActionResult> AddMenuAsync(MenuDto menuDto) => Single(await _securityService.AddMenuAsync(menuDto));

        #endregion

        #region Option


        /// <summary>
        /// Consultar todas las opciones de un perfil
        /// </summary>
        /// <returns>Lista dto de Opciones de perfil</returns>
        [AllowAnonymous]
        [HttpGet("getalloptions")]
        public async Task<IActionResult> GetAllOptions() => Single(await _securityService.GetAllOptionsAsync());


        #endregion

    }
}
