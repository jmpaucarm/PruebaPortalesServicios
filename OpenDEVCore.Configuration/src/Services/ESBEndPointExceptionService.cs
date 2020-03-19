using AutoMapper;
using Core.Cache;
using Core.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Repositories;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Services
{
    public class ESBEndPointExceptionService : IESBEndPointExceptionService
    {
        private readonly IESBEndPointExceptionRepository _iESBEndPointExceptionRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;

        public ESBEndPointExceptionService(
            IESBEndPointExceptionRepository iESBEndPointExceptionRepository,
            IConfigurationRepository configurationRepository,
            IDistributedCache cache,
            IMapper mapper
            )
        {
            _iESBEndPointExceptionRepository = iESBEndPointExceptionRepository;
            _configurationRepository = configurationRepository;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<ResourceExDescription> GetByErrorCodeAndEndPointCodeAsync(string endPointErrorCode, string endPointCode)
        {
            var (existe, data) = await _cache.GetOrAddAsync($"{endPointCode}{endPointErrorCode}", null, async () =>
                        {
                            var errEsb = await _iESBEndPointExceptionRepository.GetByErrorCodeAndEndPointCodeAsync(endPointErrorCode, endPointCode);
                            return errEsb == null ? null : _mapper.Map<EsbendPointExceptionDto>(errEsb);
                        });

            if (!existe)
                (existe, data) = await _cache.GetOrAddAsync($"ESB999", null, async () =>
                {
                    var errEsb = await _iESBEndPointExceptionRepository.GetByErrorCodeAndEndPointCodeAsync("999", "ESB");
                    return errEsb == null ? null : _mapper.Map<EsbendPointExceptionDto>(errEsb);
                });

            return existe ? _mapper.Map<ResourceExDescription>(data) : null;

        }



    }
}
