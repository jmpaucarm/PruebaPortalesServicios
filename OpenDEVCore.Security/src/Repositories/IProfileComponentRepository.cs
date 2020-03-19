using System.Collections.Generic;
using System.Threading.Tasks;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public interface IProfileComponentRepository
    {
        Task<List<ProfileComponent>> GetProfileComponentsByProfileId(int profileId);

        Task<List<ProfileComponent>> GetProfileComponentsByProfileCode(string profileCode);
    }
}