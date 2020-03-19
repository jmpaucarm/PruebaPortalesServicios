using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface IWaterMarkRepository : ICRUD<WaterMark>
    {

        Task<WaterMark> GetByCode(string codeType, string institucion);

        Task<WaterMark> GetById(int id);

        Task<List<WaterMark>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}
