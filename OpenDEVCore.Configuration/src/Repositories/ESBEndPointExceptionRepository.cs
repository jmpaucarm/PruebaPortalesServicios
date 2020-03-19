using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Configuration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Repositories
{
    public class ESBEndPointExceptionRepository : IESBEndPointExceptionRepository
    {

        private readonly ConfigurationSCContext _ConfigurationSCContext;


        public ESBEndPointExceptionRepository(ConfigurationSCContext ConfigurationSCContext)
        {
            _ConfigurationSCContext = ConfigurationSCContext;
        }


        public Task<EsbendPointException> GetByErrorCodeAndEndPointCodeAsync(string endPointErrorCode, string endPointCode)
        {
            return _ConfigurationSCContext.EsbendPointException.
                Include(y => y.IdEsbendPointNavigation).
                Include(y => y.IdEsbexceptionNavigation).
                AsNoTracking().SingleOrDefaultAsync(x => x.IdEsbendPointNavigation.Code.Equals(endPointCode) && x.EndPointErrorCode.Equals(endPointErrorCode));
        }


    }
}
