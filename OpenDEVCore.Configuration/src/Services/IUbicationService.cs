using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Dto;


namespace OpenDEVCore.Configuration.Services
{
    public interface IUbicationService
    {

        Task<object> GetAllGeographicLocations();
        Task<List<GeographicLocation1Dto>> GetAllLocation1();
        Task<GeographicLocation1Dto> GetByCodeLocation1Async(string code);
        Task<GeographicLocation1Dto> GetByIdLocation1Async(int id);
        Task<bool> EditLocation1Async(GeographicLocation1Dto userDto);
        Task<int> AddLocation1Async(GeographicLocation1Dto userDto);


        Task<List<GeographicLocation2Dto>> GetAllLocation2(int id);
        Task<List<GeographicLocation2Dto>> GetAllLocation2ByCode(string code);
        Task<List<GeographicLocation2Dto>> GetAllOnlyLocation2();
        Task<GeographicLocation2Dto> GetByCodeLocation2Async(string code);
        Task<GeographicLocation2Dto> GetByIdLocation2Async(int id);
        Task<bool> EditLocation2Async(GeographicLocation2Dto userDto);
        Task<int> AddLocation2Async(GeographicLocation2Dto userDto);

        Task<List<GeographicLocation3Dto>> GetAllLocation3(int id);
        Task<List<GeographicLocation3Dto>> GetAllLocation3ByCode(string code);
        Task<GeographicLocation3Dto> GetByCodeLocation3Async(string code);
        Task<GeographicLocation3Dto> GetByIdLocation3Async(int id);
        Task<bool> EditLocation3Async(GeographicLocation3Dto userDto);
        Task<int> AddLocation3Async(GeographicLocation3Dto userDto);

        Task<List<GeographicLocation4Dto>> GetAllLocation4(int id);
        Task<List<GeographicLocation4Dto>> GetAllLocation4ByCode(string code);
        Task<GeographicLocation4Dto> GetByCodeLocation4Async(string code);
        Task<GeographicLocation4Dto> GetByIdLocation4Async(int id);
        Task<bool> EditLocation4Async(GeographicLocation4Dto userDto);
        Task<int> AddLocation4Async(GeographicLocation4Dto userDto);


    }
}
