using AutoMapper;
using Core.General;
using Core.Types;
using Microsoft.Extensions.Caching.Distributed;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Services
{
    public class UbicationService : IUbicationService
    {

        private readonly IUbicationRepository _ubicationRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IDistributedCache _cache;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;
        public UbicationService(
            IUbicationRepository ubicationRepository,
            IConfigurationRepository configurationRepository,
            IDistributedCache cache,
            IMapper mapper,
            IExMessages iExMessages
            )
        {
            _ubicationRepository = ubicationRepository;
            _configurationRepository = configurationRepository;
            _cache = cache;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }

        public async Task<object> GetAllGeographicLocations()
        => new
        {
            geographicLocation1 = _mapper.Map<List<LightGeographicLocation>>(await _ubicationRepository.GetAllLocation1()),
            geographicLocation2 = _mapper.Map<List<LightGeographicLocation>>(await _ubicationRepository.GetAllOnlyLocation2()),
            geographicLocation3 = _mapper.Map<List<LightGeographicLocation>>(await _ubicationRepository.GetAllOnlyLocation3()),
            geographicLocation4 = _mapper.Map<List<LightGeographicLocation>>(await _ubicationRepository.GetAllOnlyLocation4()),
        };



        public async Task<List<GeographicLocation1Dto>> GetAllLocation1()
        {
            var ubication = await _ubicationRepository.GetAllLocation1();
            return ubication == null ? null : _mapper.Map<List<GeographicLocation1Dto>>(ubication);
        }
        public async Task<GeographicLocation1Dto> GetByCodeLocation1Async(string code)
        {
            var ubication = await _ubicationRepository.GetByCodeLocation1Async(code);
            return ubication == null ? null : _mapper.Map<GeographicLocation1Dto>(ubication);
        }
        public async Task<GeographicLocation1Dto> GetByIdLocation1Async(int id)
        {
            var ubication = await _ubicationRepository.GetByIdLocation1Async(id);
            return ubication == null ? null : _mapper.Map<GeographicLocation1Dto>(ubication);
        }

        public async Task<bool> EditLocation1Async(GeographicLocation1Dto ubiDto)
        {

            var ubicationori = await GetByIdLocation1Async(ubiDto.IdGeographicLocation1);
            if (ubicationori.GeographicLocation1Code != ubiDto.GeographicLocation1Code)
                _iExMessages.IncorrectGeogrphicLocationCode.Throw();


            //modifica los datos del registro
            var ubication = _mapper.Map<Entities.GeographicLocation1>(ubiDto);

            _ubicationRepository.EditLocation1(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddLocation1Async(GeographicLocation1Dto ubiDto)
        {

            var ubicationori = await GetByCodeLocation1Async(ubiDto.GeographicLocation1Code);
            if (ubicationori != null)
                _iExMessages.EntityAllreadyExists.Throw();


            //crea el ef de catalogo
            var ubication = _mapper.Map<Entities.GeographicLocation1>(ubiDto);

            //crea el registro en la tabla
            await _ubicationRepository.AddLocation1Async(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return ubication.IdGeographicLocation1;
        }

        public async Task<List<GeographicLocation2Dto>> GetAllLocation2(int id)
        {
            var ubication = await _ubicationRepository.GetAllLocation2(id);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation2Dto>>(ubication);
        }

        public async Task<List<GeographicLocation2Dto>> GetAllOnlyLocation2()
        {
            var ubication = await _ubicationRepository.GetAllOnlyLocation2();
            return ubication == null ? null : _mapper.Map<List<GeographicLocation2Dto>>(ubication);
        }
        public async Task<GeographicLocation2Dto> GetByCodeLocation2Async(string code)
        {
            var ubication = await _ubicationRepository.GetByCodeLocation2Async(code);
            return ubication == null ? null : _mapper.Map<GeographicLocation2Dto>(ubication);
        }
        public async Task<GeographicLocation2Dto> GetByIdLocation2Async(int id)
        {
            var ubication = await _ubicationRepository.GetByIdLocation2Async(id);
            return ubication == null ? null : _mapper.Map<GeographicLocation2Dto>(ubication);
        }

        public async Task<bool> EditLocation2Async(GeographicLocation2Dto ubiDto)
        {
            var ubicationori = await GetByIdLocation2Async(ubiDto.IdGeographicLocation2);
            if (ubicationori.GeographicLocation2Code != ubiDto.GeographicLocation2Code)
                _iExMessages.IncorrectGeogrphicLocationCode.Throw();


            //modifica los datos del registro
            var ubication = _mapper.Map<Entities.GeographicLocation2>(ubiDto);

            _ubicationRepository.EditLocation2(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddLocation2Async(GeographicLocation2Dto ubiDto)
        {
            var ubicationori = await GetByCodeLocation2Async(ubiDto.GeographicLocation2Code);
            if (ubicationori != null)
                _iExMessages.EntityAllreadyExists.Throw();

            //crea el ef de catalogo
            var ubication = _mapper.Map<Entities.GeographicLocation2>(ubiDto);

            //crea el registro en la tabla
            await _ubicationRepository.AddLocation2Async(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return ubication.IdGeographicLocation2;
        }




        public async Task<List<GeographicLocation3Dto>> GetAllLocation3(int id)
        {
            var ubication = await _ubicationRepository.GetAllLocation3(id);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation3Dto>>(ubication);
        }
        public async Task<GeographicLocation3Dto> GetByCodeLocation3Async(string code)
        {
            var ubication = await _ubicationRepository.GetByCodeLocation3Async(code);
            return ubication == null ? null : _mapper.Map<GeographicLocation3Dto>(ubication);
        }
        public async Task<GeographicLocation3Dto> GetByIdLocation3Async(int id)
        {
            var ubication = await _ubicationRepository.GetByIdLocation3Async(id);
            return ubication == null ? null : _mapper.Map<GeographicLocation3Dto>(ubication);
        }

        public async Task<bool> EditLocation3Async(GeographicLocation3Dto ubiDto)
        {
            var ubicationori = await GetByIdLocation3Async(ubiDto.IdGeographicLocation3);
            if (ubicationori.GeographicLocation3Code != ubiDto.GeographicLocation3Code)
                _iExMessages.IncorrectGeogrphicLocationCode.Throw();


            //modifica los datos del registro
            var ubication = _mapper.Map<Entities.GeographicLocation3>(ubiDto);

            _ubicationRepository.EditLocation3(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddLocation3Async(GeographicLocation3Dto ubiDto)
        {
            var ubicationori = await GetByCodeLocation3Async(ubiDto.GeographicLocation3Code);
            if (ubicationori != null)
                _iExMessages.EntityAllreadyExists.Throw();


            //crea el ef de catalogo
            var ubication = _mapper.Map<Entities.GeographicLocation3>(ubiDto);

            //crea el registro en la tabla
            await _ubicationRepository.AddLocation3Async(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return ubication.IdGeographicLocation3;
        }




        public async Task<List<GeographicLocation4Dto>> GetAllLocation4(int id)
        {
            var ubication = await _ubicationRepository.GetAllLocation4(id);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation4Dto>>(ubication);
        }
        public async Task<GeographicLocation4Dto> GetByCodeLocation4Async(string code)
        {
            var ubication = await _ubicationRepository.GetByCodeLocation4Async(code);
            return ubication == null ? null : _mapper.Map<GeographicLocation4Dto>(ubication);
        }
        public async Task<GeographicLocation4Dto> GetByIdLocation4Async(int id)
        {
            var ubication = await _ubicationRepository.GetByIdLocation4Async(id);
            return ubication == null ? null : _mapper.Map<GeographicLocation4Dto>(ubication);
        }

        public async Task<bool> EditLocation4Async(GeographicLocation4Dto ubiDto)
        {
            var ubicationori = await GetByIdLocation4Async(ubiDto.IdGeographicLocation4);
            if (ubicationori.GeographicLocation4Code != ubiDto.GeographicLocation4Code)
                _iExMessages.IncorrectGeogrphicLocationCode.Throw();


            //modifica los datos del registro
            var ubication = _mapper.Map<Entities.GeographicLocation4>(ubiDto);

            _ubicationRepository.EditLocation4(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddLocation4Async(GeographicLocation4Dto ubiDto)
        {
            var ubicationori = await GetByCodeLocation4Async(ubiDto.GeographicLocation4Code);
            if (ubicationori != null)
                _iExMessages.EntityAllreadyExists.Throw();


            //crea el ef de catalogo
            var ubication = _mapper.Map<Entities.GeographicLocation4>(ubiDto);

            //crea el registro en la tabla
            await _ubicationRepository.AddLocation4Async(ubication);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return ubication.IdGeographicLocation4;
        }

        public async Task<List<GeographicLocation2Dto>> GetAllLocation2ByCode(string code)
        {
            var ubication = await _ubicationRepository.GetAllLocation2ByCode(code);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation2Dto>>(ubication);
        }

        public async Task<List<GeographicLocation3Dto>> GetAllLocation3ByCode(string code)
        {
            var ubication = await _ubicationRepository.GetAllLocation3ByCode(code);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation3Dto>>(ubication);
        }

        public async Task<List<GeographicLocation4Dto>> GetAllLocation4ByCode(string code)
        {
            var ubication = await _ubicationRepository.GetAllLocation4ByCode(code);
            return ubication == null ? null : _mapper.Map<List<GeographicLocation4Dto>>(ubication);
        }
    }
}
