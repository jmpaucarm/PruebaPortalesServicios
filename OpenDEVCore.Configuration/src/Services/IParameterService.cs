using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Dto;

namespace OpenDEVCore.Configuration.Services
{
    public interface IParameterService
    {
        Task<ParameterDto> GetAsync(string code);
        Task<ParameterDto> GetByIdAsync(int id);
        Task<bool> FindParameterAsync(string code);
        Task<List<ParameterDto>> GetAllAsync();
        Task<bool> EditAsync(ParameterDto parameterDto);
        Task<int> AddAsync(ParameterDto parameterDto);

    }
}
