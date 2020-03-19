using OpenDEVCore.Security.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Services
{
    public interface IOptionService
    {
        Task<List<OptionDto>> GetAllAsync();
    }
}
