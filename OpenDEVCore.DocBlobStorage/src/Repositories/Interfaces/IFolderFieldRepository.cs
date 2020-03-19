using System.Threading.Tasks;
using OpenDEVCore.DocBlobStorage.Entities;

namespace OpenDEVCore.DocBlobStorage.Repositories.Implementations
{
    public interface IFolderFieldRepository
    {
        Task<int> Add(FolderField entFolderField);
    }
}