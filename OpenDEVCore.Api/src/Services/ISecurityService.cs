using Core.Mvc;
using Core.Types;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Queries;
using RestEase;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ISecurityService : IProxy
    {

        #region IDENTITY
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmnd"></param>
            /// <returns></returns>
            [AllowAnyStatusCode]
            [Post("identity/signin")]
            Task<CoreResponse> SignInAsync([Body] UserGeneral cmnd);
        
            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmnd"></param>
            /// <returns></returns>
            [AllowAnyStatusCode]
            [Post("identity/signout")]
            Task SignOutAsync([Body] UserGeneral cmnd);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmnd"></param>
            /// <returns></returns>
            [AllowAnyStatusCode]
            [Post("identity/changepassword")]
            Task <CoreResponse> ChangePasswordAsync([Body] UserGeneral cmnd);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cmnd"></param>
            /// <returns></returns>
            [AllowAnyStatusCode]
            [Post("identity/connect")]
            Task<CoreResponse> ConnectAsync([Body] UserGeneral cmnd);

        #endregion

        #region USER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("user/edit")]
        Task<CoreResponse> PostAsync([Body]EditUserDto user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("user/add")]
        Task<CoreResponse> PostAsync([Body]AddUserDto user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("user/getuserprofiles")]
        Task<CoreResponse> GetUserProfiles([Query] UserGeneral user);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("user/getall")]
        Task<CoreResponse> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("user/get")]
        Task<CoreResponse> GetAsync([Query] UserGeneral query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("user/find")]
        Task<CoreResponse> FindAsync([Query] UserGeneral query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("user/browseall")]
        Task<PagedResult<UserDto>> BrowseAllAsync([Query] BrowseAllUsers query);
        #endregion

        #region PROFILES

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("profile/getallprofiles")]
        Task<CoreResponse> GetAllProfileAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("profile/findprofilebycode")]
        Task<CoreResponse> FindProfileByCode([Query] string code, [Query] int idInstitution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("profile/getprofilebyid")]
        Task<CoreResponse> GetProfileById([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("profile/getprofilebycode")]
        Task<CoreResponse> GetProfileByCode([Query] string code, [Query] int idInstitution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("profile/addprofile")]
        Task<CoreResponse> PostAsync([Body]AddProfileDto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("profile/editprofile")]
        Task<CoreResponse> PostAsync([Body]EditProfileDto ctlgo);

        #endregion

        #region MENU

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("menu/getallmenus")]
        Task<CoreResponse> GetAllMenusAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("menu/getallmenuscreens")]
        Task<CoreResponse> GetAllMenuScreensAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("menu/editmenu")]
        Task<CoreResponse> EditMenuAsync([Body]MenuDto menu);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("menu/addmenu")]
        Task<CoreResponse> AddMenuAsync([Body]MenuDto menu);

        #endregion

        #region OPTION
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("option/getalloptions")]
        Task<CoreResponse> GetAllOptionsAsync();

        #endregion
    }
}
