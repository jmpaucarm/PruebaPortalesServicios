using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Security.Dto;

namespace OpenDEVCore.Security.Services
{
    public interface IProfileService
    {
        Task<List<ProfileDto>> GetAllAsync();

        Task<ProfileDto> GetByIdAsync(int id);
        Task<bool> FindByCodeAsync(string code, int idInstitution);
        Task<ProfileDto> GetByCodeInstitutionAsync(string code, int idInstitution);
        Task<bool> EditAsync(EditProfileDto ctlgDto);
        Task<int> AddAsync(AddProfileDto ctlgDto);

    }
}
