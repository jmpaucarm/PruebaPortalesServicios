using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Dto;

namespace OpenDEVCore.Configuration.Services
{
    public interface IOfficeService
    {
        Task<List<OfficeDto>> GetOffices(int[] ids);
    }
}