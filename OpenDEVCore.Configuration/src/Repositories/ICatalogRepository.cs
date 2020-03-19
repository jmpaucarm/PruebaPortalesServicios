using OpenDEVCore.Configuration.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace OpenDEVCore.Configuration.Repositories
{
    public interface ICatalogRepository
    {
        Task<bool> FindAsync(string code);
        Task<Catalogue> GetByPredicateAsync(Expression<Func<Catalogue, bool>> predicate);

        Task<List<Catalogue>> GetListByPredicateAsync(Expression<Func<Catalogue, bool>> predicate);
        //Task<List<Catalogue>> GetByCodesAsync(string codes, int idInstitution);
        Catalogue Edit(Catalogue item);
        Task AddAsync(Catalogue item);
    }
}
