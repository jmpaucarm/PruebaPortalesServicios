using OpenDEVCore.Configuration.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IInstitutionRepository
    {
        Task<bool> FindAsync(string ruc);

        Task<Institution> GetByCodeAsync(string code);
        Task<Institution> GetByIdAsync(int code);

        Task<List<Institution>> AllAsync(bool onlyActive, bool onlyInstitution);

        Task AddAsync(Institution item);

        Institution Edit(Institution item);
        
    }
}
