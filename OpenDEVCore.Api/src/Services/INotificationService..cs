using Core.Mvc;
using RestEase;
using OpenDEVCore.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Types;


namespace OpenDEVCore.Api.Services
{

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]

    public interface INotificationService : IProxy
    {
        #region Provider
        [AllowAnyStatusCode]
        [Get("Provider/getproviderbycode")]
        Task<CoreResponse<ProviderDto>> GetByCodeAsyncProvider([Query]string code, [Query]string chanel, [Query]string institution);

        [AllowAnyStatusCode]
        [Get("Provider/findprovider")]
        Task<CoreResponse<bool>> FindAsyncProvider([Query]string code, [Query]string chanel, [Query]string institution);

        [AllowAnyStatusCode]
        [Get("Provider/getproviderbyid")]
        Task<CoreResponse<ProviderDto>> GetByIdAsyncProvider([Query]int id);

        [AllowAnyStatusCode]
        [Get("Provider/getallproviders")]
        Task<CoreResponse<List<ProviderDto>>> GetAllAsyncProvider();

        [AllowAnyStatusCode]
        [Post("Provider/addprovider")]
        Task<CoreResponse<int>> AddAsyncProvider([Body]ProviderDto ProviderDto);
        
        [AllowAnyStatusCode]
        [Post("Provider/editprovider")]
        Task<CoreResponse<bool>> EditAsyncProvider([Body]ProviderDto ProviderDto);
        #endregion

        #region Template
        [AllowAnyStatusCode]
        [Get("Template/gettemplatebycode")]
        Task<CoreResponse<TemplateDto>> GetByCodeAsyncTemplate([Query]string code, [Query]string chanel, [Query]string institution);

        [AllowAnyStatusCode]
        [Get("Template/findtemplate")]
        Task<CoreResponse<bool>> FindAsyncTemplate([Query]string code, [Query]string chanel, [Query]string institution);

        [AllowAnyStatusCode]
        [Get("Template/gettemplatebyid")]
        Task<CoreResponse<TemplateDto>> GetByIdAsyncTemplate([Query]int id);

        [AllowAnyStatusCode]
        [Get("Template/getalltemplate")]
        Task<CoreResponse<List<TemplateDto>>> GetAllAsyncTemplate();

        [AllowAnyStatusCode]
        [Post("Template/addtemplate")]
        Task<CoreResponse<int>> AddAsyncTemplate([Body]TemplateDto parDto);

        [AllowAnyStatusCode]
        [Post("Template/edittemplate")]
        Task<CoreResponse<bool>> EditAsyncTemplate([Body]TemplateDto parDto);
        #endregion

        #region Campaign

        [AllowAnyStatusCode]
        [Post("Campaign/addcampaign")]
        Task<CoreResponse<int>> AddAsyncCampaign([Body]CampaignDto campaignDto);

        #endregion

        #region Notification

        [AllowAnyStatusCode]
        [Post("ENotification/addnotification")]
        Task<CoreResponse<int>> AddAsyncNotification([Body]NotificationsDto notificationsDtos);

        #endregion

    }
}
