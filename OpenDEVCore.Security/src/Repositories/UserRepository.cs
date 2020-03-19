using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Types;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Queries;
using Core.General;

namespace OpenDEVCore.Security.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public UserRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public async Task<User> GetAsync(string userCode) =>
            await _securityDbContext.User.AsNoTracking().Include(x => x.UserProfile).ThenInclude(post => post.IdProfileNavigation).FirstOrDefaultAsync(x => x.UserCode == userCode);

        public async Task<bool> FindAsync(string userCode) =>
            await _securityDbContext.User.AnyAsync(p => p.UserCode == userCode);

        public User Edit(User user)
        {
            _securityDbContext.User.Update(user);
            return user;
        }

        public async Task AddAsync(User user)
        {
            await _securityDbContext.User.AddAsync(user);
        }

        public async Task<PagedResult<User>> BrowseAllAsync(BrowseAllUsers id)
        {
            var pr = await _securityDbContext.User.PaginateAsync(id.Page, id.Results);
            return pr;
        }


        public async Task<List<User>> GetAllAsync()
        {
                return  await _securityDbContext.User.Include(up => up.UserProfile).ToListAsync();
        }
        public List<MenuOptionDto> GetByUserProfileOffice(int? idUser, int? idProfile, int idOffice)
        {
            var views = _securityDbContext.User
               .Join(_securityDbContext.UserProfile,
                  usr => usr.IdUser,
                  usrPro => usrPro.IdUser,
                  (usr, usrPro) => new { usr, usrPro })
               .Where(usrAndUsrPro => usrAndUsrPro.usrPro.IdProfile == idProfile && usrAndUsrPro.usr.IdUser == idUser && usrAndUsrPro.usrPro.IdOffice == idOffice)
                .Join(_securityDbContext.ProfileOption,
                  usrAndUsrPro => usrAndUsrPro.usrPro.IdProfile,
                  proOpt => proOpt.IdProfile,
                  (usrAndUsrPro, proOpt) => new { usrAndUsrPro, proOpt })
                .Join(_securityDbContext.Option,
                  usrp => usrp.proOpt.IdOption,
                  opt => opt.IdOption,
                  (usrp, opt) => new { usrp, opt })
                 .Join(_securityDbContext.Menu,
                  usrProOpt => usrProOpt.opt.IdMenu,
                  menu => menu.IdMenu,
                  (usrProOpt, menu) => new { usrProOpt, menu }).Select(s => new MenuOptionDto
                  {
                      IdMenu = s.menu.IdMenu,
                      IdMenuOrigin = s.menu.IdMenuOrigin,
                      Name = s.menu.Name,
                      RouteLink = s.menu.RouteLink,
                      Channel = s.menu.Channel,
                      Level = s.menu.Level,
                      Description = s.menu.Description,
                      Icon = s.menu.Icon,
                      Order = s.menu.Order
                  }).ToList();

            if (views.Count > 0)
            {
                var moduleSubmodule = _securityDbContext.Menu.Where(w => w.IsActive && (w.Level == "MODULE" || w.Level == "SUBMODULE")).Select(s => new MenuOptionDto
                {
                    IdMenu = s.IdMenu,
                    IdMenuOrigin = s.IdMenuOrigin,
                    Name = s.Name,
                    RouteLink = s.RouteLink,
                    Channel = s.Channel,
                    Level = s.Level,
                    Description = s.Description,
                    Icon = s.Icon,
                    Order = s.Order
                }).ToList();

                return moduleSubmodule.Union(views).ToList();
            }
            else
                return new List<MenuOptionDto>(); 
        }

        public async Task<List<User>> GetByIds(int[] ids)
        {
            return await _securityDbContext.User.Where(w => ids.Contains(w.IdUser))
            .Select(u => new User {
                IdUser = u.IdUser,
                FirstName = u.FirstName,
                SecondName = u.SecondName,
                LastName1 = u.LastName1,
                LastName2 = u.LastName2
            }).ToListAsync();
        }


        private class EqualityComparerTransaction : IEqualityComparer<MenuOptionDto>
        {
            bool IEqualityComparer<MenuOptionDto>.Equals(MenuOptionDto x, MenuOptionDto y)
            {
                return x.IdMenu == y.IdMenu;
            }

            int IEqualityComparer<MenuOptionDto>.GetHashCode(MenuOptionDto obj)
            {
                return obj.IdMenu.GetHashCode();
            }
        }
    }
}
