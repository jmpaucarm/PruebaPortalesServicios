using OpenDEVCore.Configuration.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IUbicationRepository
    {


        Task<List<GeographicLocation1>> GetAllLocation1();

        Task<GeographicLocation1> GetByCodeLocation1Async(string code);
        Task<GeographicLocation1> GetByIdLocation1Async(int id);

        void EditLocation1(GeographicLocation1 geographicLocation);
        Task AddLocation1Async(GeographicLocation1 geographicLocation);


        Task<List<GeographicLocation2>> GetAllLocation2(int id);
        Task<List<GeographicLocation2>> GetAllLocation2ByCode(string code);
        Task<List<GeographicLocation2>> GetAllOnlyLocation2();
        Task<List<GeographicLocation3>> GetAllOnlyLocation3();
        Task<List<GeographicLocation4>> GetAllOnlyLocation4();


        Task<GeographicLocation2> GetByCodeLocation2Async(string code);
        Task<GeographicLocation2> GetByIdLocation2Async(int id);

        void EditLocation2(GeographicLocation2 geographicLocation);
        Task AddLocation2Async(GeographicLocation2 geographicLocation);


        Task<List<GeographicLocation3>> GetAllLocation3(int id);

        Task<List<GeographicLocation3>> GetAllLocation3ByCode(string code);

        Task<GeographicLocation3> GetByCodeLocation3Async(string code);
        Task<GeographicLocation3> GetByIdLocation3Async(int id);

        void EditLocation3(GeographicLocation3 geographicLocation);
        Task AddLocation3Async(GeographicLocation3 geographicLocation);


        Task<List<GeographicLocation4>> GetAllLocation4(int id);

        Task<List<GeographicLocation4>> GetAllLocation4ByCode(string code);

        Task<GeographicLocation4> GetByCodeLocation4Async(string code);
        Task<GeographicLocation4> GetByIdLocation4Async(int id);

        void EditLocation4(GeographicLocation4 geographicLocation);
        Task AddLocation4Async(GeographicLocation4 geographicLocation);

    }
}
