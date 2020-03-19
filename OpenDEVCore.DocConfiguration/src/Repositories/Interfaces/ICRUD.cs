
using System.Threading.Tasks;

namespace OpenDevCore.DocConfiguration.Repositories.Interfaces
{
    public interface ICRUD<T>
    {
        //registry
        Task<int> Add(T ent);
        //edit
        Task<bool> Edit(T ent);

        //lookup methods
        Task<bool> FindById(int idEnt);

    }
}
