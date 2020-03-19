using OpenDevCore.DocConfiguration.Repositories.Interfaces;
using OpenDevCore.DocConfiguration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories
{
    public interface IFormVersionRepository : ICRUD <FormVersion>
    {
            
        Task<FormVersion> GetByCode(string codeType, string institucion);

        Task<List<FormVersion>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}
