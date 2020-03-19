using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Dto;

namespace OpenDEVCore.Configuration.Services
{
    public interface IInstitutionService
    {
        Task<bool> FindByRucAsync(string ruc);

        Task<InstitutionDto> GetByCodeAsync(string code);
        Task<InstitutionDto> GetByIdAsync(int code);
        Task<List<InstitutionDto>> GetAllAsync(bool onlyActive, bool onlyInstitution);

        Task<bool> EditAsync(InstitutionDto instDto);
        Task<int> AddAsync(InstitutionDto instDto);
    }
}
