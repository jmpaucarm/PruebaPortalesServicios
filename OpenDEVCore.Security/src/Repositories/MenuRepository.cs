using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly SecurityDBContext _securityDbContext;
        public MenuRepository(SecurityDBContext securityDbContext)
        {
            _securityDbContext = securityDbContext;
        }

        public Menu Edit(Menu menu)
        {
            _securityDbContext.Menu.Update(menu);
            return menu;
        }

        public async Task<List<Menu>> GetAllAsync() =>
            await _securityDbContext.Menu.AsNoTracking().ToListAsync();

        public async Task<List<Menu>> GetAllScreensAsync() =>
          await _securityDbContext.Menu.AsNoTracking().Where(w => w.Level == "SCREEN").ToListAsync();

        public Task<Menu> GetByIdAsync(int id) =>
        _securityDbContext.Menu.AsNoTracking().SingleOrDefaultAsync(x => x.IdMenu == id);

        public async Task AddAsync(Menu menu) => await _securityDbContext.Menu.AddAsync(menu);
    }
}
