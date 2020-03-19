using OpenDEVCore.DocBlobStorage.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Services
{
    public  interface IBoxService
    {

        Task<int> Add(BoxDto ent);
        Task<BoxDto> Edit(BoxDto ent);

        Task<BoxDto> GetByCode(string codeBoxDto, string institucion);

        Task<List<BoxDto>> GetAll(string institution, bool active);

        Task<bool> Find(string code, string institution);
    }
}
