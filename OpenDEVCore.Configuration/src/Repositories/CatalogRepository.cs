using System;
using System.Linq;
using System.Threading.Tasks;
using OpenDEVCore.Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Mvc;

namespace OpenDEVCore.Configuration.Repositories
{
    public class CatalogRepository : BaseRepository, ICatalogRepository
    {
        private readonly ConfigurationSCContext _ConfigurationSCContext;

        public CatalogRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
            
        }

        public async Task<bool> FindAsync(string code) =>
           await _ConfigurationSCContext.Catalogue.AnyAsync(p => p.Code == code && p.IsActive);
        /*

        public async Task<Catalogue> GetByCodeAsync(string code, int idInstitution)
        {
           var catalogue = await _ConfigurationSCContext.Catalogue
           .Include(y => y.CatalogueDetail).SingleOrDefaultAsync(x => x.Code == code && x.IsActive);

            if (catalogue != null)
            {
                catalogue.CatalogueDetail = catalogue.CatalogueDetail.Where(w=>w.IsActive).OrderBy(c => c.Order).ToList();
                return catalogue;
            }
            else
                return null;
        }
        public async Task<Catalogue> GetByIdAsync(int id, int idInstitution)
        {
            var catalogue = await _ConfigurationSCContext.Catalogue
            .Include(y => y.CatalogueDetail).AsNoTracking().SingleOrDefaultAsync(x => x.IdCatalogue == id && x.IsActive);

            if (catalogue != null)
            {
                catalogue.CatalogueDetail = catalogue.CatalogueDetail.Where(w => w.IsActive).OrderBy(c => c.Order).ToList();
                return catalogue;
            }
            else
                return null; 
        }
        */
        public async Task<Catalogue> GetByPredicateAsync(Expression<Func<Catalogue, bool>> predicate)
        {
            var catalogue = await _ConfigurationSCContext.Catalogue
            .Include(y => y.CatalogueDetail).AsNoTracking().SingleOrDefaultAsync(predicate);

            if (catalogue != null)
            {
                catalogue.CatalogueDetail = catalogue.CatalogueDetail.Where(w => w.IsActive).OrderBy(c => c.Order).ToList();
                return catalogue;
            }
            else
                return null;
        }


        public async Task<List<Catalogue>> GetListByPredicateAsync(Expression<Func<Catalogue, bool>> predicate)
        {
            var catalogues = await _ConfigurationSCContext.Catalogue
            .Include(dc => dc.CatalogueDetail).AsNoTracking().Where(w=>w.IsActive).ToListAsync();

            if (catalogues != null)
            {
                foreach (var item in catalogues)
                    item.CatalogueDetail = item.CatalogueDetail.Where(w => w.IsActive).OrderBy(c => c.Order).ToList();

                return catalogues;
            }
            else
                return null;
        }
        /*
        public async Task<List<Catalogue>> GetByCodesAsync(string[] listCodes, int idInstitution)
        {
            var catalogues = await _ConfigurationSCContext.Catalogue
            .Where(c => listCodes.Contains(c.Code)).Include(dc => dc.CatalogueDetail)
            .AsNoTracking().Where(w => w.IsActive).ToListAsync();

            if (catalogues != null)
            {
                foreach (var item in catalogues)
                    item.CatalogueDetail = item.CatalogueDetail.Where(w => w.IsActive).OrderBy(c => c.Order).ToList();

                return catalogues;
            }
            else
                return null;
        }
        */
        public Catalogue Edit(Catalogue catalog)
        {
            _ConfigurationSCContext.Catalogue.Update(catalog);
            return catalog;
        }
        public async Task AddAsync(Catalogue ctlg) =>
            await _ConfigurationSCContext.Catalogue.AddAsync(ctlg);
    }
}
