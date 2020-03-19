using OpenDEVCore.DocBlobStorage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public  interface IBoxRepository
    {
        Task<int> Add(Box ent);
        Task<Box> Edit(Box ent);



        Task<Box> GetByCode(string codeBox, string institucion);

        Task<List<Box>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);


    }
}
