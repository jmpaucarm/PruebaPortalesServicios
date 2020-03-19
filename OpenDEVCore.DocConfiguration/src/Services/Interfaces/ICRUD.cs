using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Services.Interfaces
{
    public interface ICRUD<T>
    {
        //registry
        Task<int> Add(T dto);
        //edit
        Task<bool> Edit(T dto);
        //lookup methods
        Task<bool> FindById(int idDto);
    }
}
