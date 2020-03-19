using OpenDEVCore.Configuration.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface IParameterRepository
    {
        Task<bool> FindAsync(string code);

        Task<Parameter> GetAsync(string code);
        Task<Parameter> GetByIdAsync(int id);

        Task<List<Parameter>> GetAllAsync();

        void Edit(Parameter parameter);
        Task AddAsync(Parameter parameter);
    }
}
