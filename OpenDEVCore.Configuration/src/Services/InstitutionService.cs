using AutoMapper;
using Core.Types;
using Microsoft.Extensions.Caching.Distributed;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Cache;

namespace OpenDEVCore.Configuration.Services
{
    public class InstitutionService : IInstitutionService
    {
        
        private readonly IInstitutionRepository _institutionRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;
        public InstitutionService(
            IInstitutionRepository institutionRepository,
            IConfigurationRepository configurationRepository,
            IDistributedCache cache,
            IMapper mapper,
            IExMessages iExMessages
            )
        {
            _institutionRepository = institutionRepository;
            _configurationRepository = configurationRepository;
            _cache = cache;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }


        public async Task<bool> FindByRucAsync(string ruc)
        {
            var ctlg = await _institutionRepository.FindAsync(ruc);
            return ctlg;
        }


        public async Task<InstitutionDto> GetByCodeAsync(string code)
        {
                var inst = await _institutionRepository.GetByCodeAsync(code);
                return inst == null ? null : _mapper.Map<InstitutionDto>(inst);
        }
        public async Task<InstitutionDto> GetByIdAsync(int code)
        {
            var (Exists, Result) = await _cache.GetOrAddAsync(code, nameof(InstitutionDto.CompanyCode), 
                    async () =>
                    {
                        var inst = await _institutionRepository.GetByIdAsync(code);
                        return inst == null ? null : _mapper.Map<InstitutionDto>(inst);
                    }
                );
            return Result;
        }

        public async Task<List<InstitutionDto>> GetAllAsync(bool onlyActive, bool onlyInstitution)
        {
            var inst = await _institutionRepository.AllAsync(onlyActive, onlyInstitution);
            return inst == null ? null : _mapper.Map<List<InstitutionDto>>(inst);
        }

        public async Task<bool> EditAsync(InstitutionDto insDto)
        {
            var exist = await _institutionRepository.FindAsync(insDto.Ruc);
            if (!exist)// valid que el catalogo no exista
                _iExMessages.EntityDoesNotExists.Throw();

            //modifica los datos del registro
            var institution = _mapper.Map<Entities.Institution>(insDto);

            _institutionRepository.Edit(institution);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();

            return true;
        }
        public async Task<int> AddAsync(InstitutionDto insDto)
        {
            var exist = await _institutionRepository.FindAsync(insDto.Ruc);
            if (exist)// valid que el catalogo no exista
                _iExMessages.EntityDoesNotExists.Throw();

            //crea el ef de catalogo
            var institution = _mapper.Map<Entities.Institution>(insDto);

            //crea el registro en la tabla
            await _institutionRepository.AddAsync(institution);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return institution.IdInstitution;
        }



    }
}
