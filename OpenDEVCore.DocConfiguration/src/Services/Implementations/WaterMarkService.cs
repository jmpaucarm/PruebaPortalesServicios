using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Entities;
using OpenDevCore.DocConfiguration.Repositories;

namespace OpenDevCore.DocConfiguration.Services
{

    public class WaterMarkService : IWaterMarkService
    {
        private readonly IWaterMarkRepository _waterMarkRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;

        public WaterMarkService(IWaterMarkRepository waterMarkRepository, IMapper mapper, IExMessages iexMessages)
        {
            _waterMarkRepository = waterMarkRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
        }
        public async Task<int> Add(WaterMarkDto dto)
        {
            var exists = await _waterMarkRepository.FindById(dto.IdWaterMark);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }
            var idNewTypeImage = await _waterMarkRepository.Add(_mapper.Map<WaterMark>(dto));
            return idNewTypeImage;

        }

        public async Task<bool> Edit(WaterMarkDto dto)
        {
            var exists = await FindById(dto.IdWaterMark);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            var entUpdate = _mapper.Map<WaterMark>(dto);
            await _waterMarkRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _waterMarkRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _waterMarkRepository.FindById(idDto);
        }

        public async Task<List<WaterMarkDto>> GetAll(string institution, bool active)
        {
            List<WaterMark> listEnt = await _waterMarkRepository.GetAll(institution, active);
            List<WaterMarkDto> listDto = _mapper.Map<List<WaterMarkDto>>(listEnt);
            return listDto;
        }

        public async  Task<WaterMarkDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _waterMarkRepository.GetByCode(codeType, institucion);
            return  _mapper.Map<WaterMarkDto>(ent);
        }

        public  async  Task<WaterMarkDto> GetById(int id)
        {
            var ent = await _waterMarkRepository.GetById(id);
            return _mapper.Map<WaterMarkDto>(ent);
        }
    }
}
