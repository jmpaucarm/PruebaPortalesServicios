using AutoMapper;
using Core.Mvc;
using Core.Types;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Services
{
    public class ParameterService : BaseService, IParameterService
    {
        
        private readonly IParameterRepository _parameterRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;
        public ParameterService(
            IParameterRepository parameterRepository,
            IConfigurationRepository configurationRepository,
            IMapper mapper,
            IExMessages iExMessages
            )
        {
            _parameterRepository = parameterRepository;
            _configurationRepository = configurationRepository;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }

        public async Task<ParameterDto> GetByIdAsync(int id)
        {
            
            var inst = await _parameterRepository.GetByIdAsync(id);
            return inst == null ? null : _mapper.Map<ParameterDto>(inst);
        }

        public async Task<bool> FindParameterAsync(string code) =>
          await _parameterRepository.FindAsync(code);



        public async Task<ParameterDto> GetAsync(string code)
        {
            //ojo poner la logica por institucion
            //var value = _session.Get<UserSession>("session");
            var inst = await _parameterRepository.GetAsync(code);
            //para pruebas de la sessión inst.Description += $"[INST:{_userSession.InstitutionID}]; [IDUSER:{_userSession.UserID}]";
            return inst == null ? null : _mapper.Map<ParameterDto>(inst);
        }
     
        public async Task<List<ParameterDto>> GetAllAsync()
        {
            var inst = await _parameterRepository.GetAllAsync();
            return inst == null ? null : _mapper.Map<List<ParameterDto>>(inst);
        }

        public async Task<bool> EditAsync(ParameterDto parDto)
        {
            var exist = await _parameterRepository.FindAsync(parDto.Code);
            if (!exist)// valid que el catalogo no exista
                _iExMessages.EntityDoesNotExists.Throw();

            //modifica los datos del registro
            var parameter = _mapper.Map<Entities.Parameter>(parDto);

            _parameterRepository.Edit(parameter);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();

            return true;
        }
        public async Task<int> AddAsync(ParameterDto parDto)
        {
            var exist = await _parameterRepository.FindAsync(parDto.Code);
            if (exist)// valid que el catalogo no exista
                _iExMessages.EntityAllreadyExists.Throw();

            //crea el ef de catalogo
            var parameter = _mapper.Map<Entities.Parameter>(parDto);

            //crea el registro en la tabla
            await _parameterRepository.AddAsync(parameter);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return parameter.IdParameter;
        }

    }
}
