using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services
{
    public interface IWaterMarkService : ICRUD<WaterMarkDto>
    {
        Task<WaterMarkDto> GetByCode(string codeType, string institucion);

        Task<List<WaterMarkDto>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);

        Task<WaterMarkDto> GetById(int id);
    }
}
