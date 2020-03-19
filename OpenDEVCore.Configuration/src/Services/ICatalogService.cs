using OpenDEVCore.Configuration.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Services
{
    public interface ICatalogService
    {
        Task<CatalogueDto> GetByCodeAsync(string query,int idInstitution);
        Task<CatalogueDto> GetByIdAsync(int id, int idInstitution);
        Task<bool> FindByCodeAsync(string query, int idInstitution);
        Task<List<CatalogueDto>> GetAllAsync();
        Task<List<CatalogueDto>> GetByCodesAsync(string query, int idInstitution);
        Task<bool> EditAsync(CatalogueDto ctlgDto);
        Task<int> AddAsync(CatalogueDto ctlgDto);
    }
}
