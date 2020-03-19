using Core.Mvc;
using Core.Types;
using Newtonsoft.Json;
using OpenDEVCore.Configuration.Dto;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Proxy
{
    public interface IConfigurationService : IProxy
    {
        [AllowAnyStatusCode]
        [Get("institution/getinstitutionbyid")]
        Task<CoreResponse<InstitutionDto>> GetInstitutionById([Query]int id);

        [AllowAnyStatusCode]
        [Get("parameter/getparameterbycode")]
        Task<CoreResponse<ParameterDto>> GetParameter([Query]string code, [Query]int institution);//, [Header("Session")] string session);


        [AllowAnyStatusCode]
        [Get("Office/getGetOffices")]
        Task<CoreResponse<List<OfficeDto>>> GetOffices([Query]int[] ids);
    }
}
