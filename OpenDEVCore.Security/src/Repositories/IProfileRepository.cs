using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public interface IProfileRepository
    {
        Task<List<Profile>> GetAllAsync();
        Task<bool> FindAsync(string code, int idInstitution);

        Task<Profile> GetByCodeInstitutionAsync(string code, int idInstitution);
        Task<Profile> GetByCodeAsync(string code);
        Task<Profile> GetByIdAsync(int id);

        Profile Edit(Profile profile);
        Task AddAsync(Profile profile);

    }
}
