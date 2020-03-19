using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.DocBlobStorage.Dto;

namespace OpenDEVCore.DocBlobStorage.Services
{
    public interface IFolderServices
    {
        Task<int> Add(FolderDto entFolder);
        Task<List<FolderDto>> GetAll(string institution);
        Task<FolderDto> GetById(int id);
        Task<bool> FindById(int id);
        Task<FolderDto> UpdateFolder(FolderDto entFolder);
    }
}