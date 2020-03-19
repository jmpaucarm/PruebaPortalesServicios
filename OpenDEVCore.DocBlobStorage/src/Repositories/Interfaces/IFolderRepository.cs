using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Entities;

namespace OpenDEVCore.DocBlobStorage.Repositories
{
    public interface IFolderRepository
    {
        Task<int> Add(Folder entFolder);
        Task<List<Folder>> GetAll(string institution);
        Task<Folder> GetById(int id);
        Task<bool> FindById(int id);
        Task<Folder> UpdateFolder(Folder entFolder);
    }
}