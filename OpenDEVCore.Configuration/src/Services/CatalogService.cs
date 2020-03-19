using AutoMapper;
using Core.Cache;
using Core.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Entities;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Services
{
    public class CatalogService : BaseService, ICatalogService
    {
        
        private readonly ICatalogRepository _catalogRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;

        public CatalogService(
            ICatalogRepository catalogRepository,
            IConfigurationRepository configurationRepository,
            IDistributedCache cache,
            IMapper mapper,
            IExMessages iExMessages
            )
        {
            _catalogRepository = catalogRepository;
            _configurationRepository = configurationRepository;
            _cache = cache;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }

        public async Task<CatalogueDto> GetByCodeAsync(string code, int idInstitution)
        {
            var (Exists, Result) = await _cache.GetOrAddAsync(code, "IdCatalogue", async () =>
            {
                var ctlg = await _catalogRepository.GetByPredicateAsync(cat => cat.Code == code && cat.IsActive);
                return ctlg == null ? null : _mapper.Map<CatalogueDto>(ctlg);
            });

            //Result.Description += $"[INST:{_userSession.InstitutionID}]; [IDUSER:{_userSession.UserID}]";//sólo prueba de concurrencia de la Session => comentar la línea.
            return Result;           
        }

        public async Task<CatalogueDto> GetByIdAsync(int id, int idInstitution)
        {
            var (Exists, Result) = await _cache.GetOrAddAsync(id, "Code", async () =>
            {
                var ctlg = await _catalogRepository.GetByPredicateAsync(cat => cat.IdCatalogue == id && cat.IsActive);
                return ctlg == null ? null : _mapper.Map<CatalogueDto>(ctlg);
            });

            if (Exists) //verifica si la consulta al caché o BDD devolvió un objeto
                return Result; //se obtiene el objeto consultado
            else
                return null;
        }
        public async Task<List<CatalogueDto>> GetByCodesAsync(string query, int idInstitution)
        {
            var listCodes = query.Split(',');
            List<CatalogueDto> lista = new List<CatalogueDto>();

            for(int i = 0; i < listCodes.Length; i++)
            {
                var dto = await GetByCodeAsync(listCodes[i], idInstitution);
                if (dto != null)
                    lista.Add(dto);
            }

            return lista;
        }

        public async Task<bool> FindByCodeAsync(string code, int idInstitution) =>
            await _catalogRepository.FindAsync(code);


        public async Task<List<CatalogueDto>> GetAllAsync()
        {
            var result = await _catalogRepository.GetListByPredicateAsync(cat => cat.IsActive);
            return _mapper.Map<List<CatalogueDto>>(result);
        }

        public async Task<bool> EditAsync(CatalogueDto ctlgDto)
        {
            var exist = await _catalogRepository.FindAsync(ctlgDto.Code);
            if (!exist)// valid que el catalogo no exista
                _iExMessages.EntityDoesNotExists.Throw();

            //var catalog = await _catalogRepository.GetAsync(ctlgDto.Code);
            var catalog = _mapper.Map<Catalogue>(ctlgDto);

            _catalogRepository.Edit(catalog);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddAsync(CatalogueDto ctlgDto)
        {
            var exist = await _catalogRepository.FindAsync(ctlgDto.Code);
            if (exist)// valid que el catalogo no exista
                _iExMessages.EntityAllreadyExists.Throw();

            //crea el ef de catalogo
            var newCatalog = _mapper.Map<Catalogue>(ctlgDto);

            //crea el registro en la tabla
            await _catalogRepository.AddAsync(newCatalog);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return newCatalog.IdCatalogue;
        }
    }
}
