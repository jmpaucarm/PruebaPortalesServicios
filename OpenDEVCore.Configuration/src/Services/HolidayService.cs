using AutoMapper;
using Core.Types;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Entities;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OpenDEVCore.Configuration.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;

        public HolidayService(
            IHolidayRepository holidayRepository,
            IConfigurationRepository configurationRepository,
            IMapper mapper,
            IExMessages iExMessages
            )
        {
            _holidayRepository = holidayRepository;
            _configurationRepository = configurationRepository;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }

        public async Task<HolidayDto> GetByIdAsync(int id)
        {
            var inst = await _holidayRepository.GetByIdAsync(id);
            return inst == null ? null : _mapper.Map<HolidayDto>(inst);
        }
        public async Task<HolidayDto> GetByDateAsync(DateTime holiday, int idUbication)
        {
            var inst = await _holidayRepository.GetByDateAsync(holiday, idUbication);
            return inst == null ? null : _mapper.Map<HolidayDto>(inst);
        }

        public async Task<bool> FindHolidayAsync(DateTime holiday, int idUbication) =>
            await _holidayRepository.FindAsync(holiday, idUbication);


        public async Task<List<HolidayDto>> GetAllAsync()
        {
            var inst = await _holidayRepository.GetAllAsync();

            return inst == null ? null : _mapper.Map<List<HolidayDto>>(inst);
        }

        public async Task<bool> EditAsync(HolidayDto holidayDto)
        {

            //modifica los datos del registro
            var holiday = _mapper.Map<Holiday>(holidayDto);

            var exist = await _holidayRepository.FindAsync(holiday.DateHoliday.Date, holiday.IdGeographicLocation2);
            if (!exist)// valid que el catalogo no exista
                _iExMessages.EntityDoesNotExists.Throw();


            _holidayRepository.Edit(holiday);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return true;
        }
        public async Task<int> AddAsync(HolidayDto holidayDto)
        {


            //crea el ef de catalogo
            Holiday holiday = _mapper.Map<Holiday>(holidayDto);


            var exist = await _holidayRepository.FindAsync(holiday.DateHoliday.Date, holiday.IdGeographicLocation2);
            if (exist)// valid que el catalogo no exista
                _iExMessages.EntityAllreadyExists.Throw();

            //crea el registro en la tabla
            holiday.Add(holiday.DateHoliday);

            await _holidayRepository.AddAsync(holiday);

            //commit en la base de datos
            await _configurationRepository.SaveAsync();
            return holiday.IdHoliday;
        }

    }
}
