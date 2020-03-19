
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Repositories;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration.Services
{
    public class FormVersionService : IFormVersionService
    {
        private readonly IFormVersionRepository _formVersionRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;

        public FormVersionService(IFormVersionRepository formVersionRepository, IMapper mapper, IExMessages iexMessages)
        {
            _formVersionRepository = formVersionRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
        }
        public async Task<int> Add(FormVersionDto dto)
        {
            var exists = await _formVersionRepository.FindById(dto.IdFormVersion);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }
            var idNewTypeImage = await _formVersionRepository.Add(_mapper.Map<FormVersion>(dto));
            return idNewTypeImage;

        }

        public async Task<bool> Edit(FormVersionDto dto)
        {
            var exists = await FindById(dto.IdFormVersion);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            var dtoUpdate = _mapper.Map<FormVersion>(dto);
            await _formVersionRepository.Edit(dtoUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _formVersionRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _formVersionRepository.FindById(idDto);
        }

        public async Task<List<FormVersionDto>> GetAll(string institution, bool active)
        {
            List<FormVersion> listEnt = await _formVersionRepository.GetAll(institution, active);
            List<FormVersionDto> listDto = _mapper.Map<List<FormVersionDto>>(listEnt);
            return listDto;
        }

        public async Task<FormVersionDto> GetByCode(string codeType, string institucion)
        {
            var dto = await _formVersionRepository.GetByCode(codeType, institucion);
            return  _mapper.Map<FormVersionDto>(dto);
        }
    }
}
