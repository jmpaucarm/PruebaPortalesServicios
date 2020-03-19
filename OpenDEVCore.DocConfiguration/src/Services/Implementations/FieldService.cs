using AutoMapper;
using Core.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Repositories;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OpenDevCore.DocConfiguration.Services
{
    public class FieldService : BaseService, IFieldService

    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;

        public FieldService(IFieldRepository fieldRepository, IMapper mapper, IExMessages iexMessages)

        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
        }

        public async Task<int> Add(FieldDto dto)
        {
            var exists = await _fieldRepository.FindById(dto.IdField);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }
            var idNewField = await _fieldRepository.Add(_mapper.Map<Field>(dto));
            return idNewField;
        }

        public async Task<bool> Edit(FieldDto dto)
        {
            var exists = await _fieldRepository.FindById(dto.IdField);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            var entUpdate = _mapper.Map<Field>(dto);
            await _fieldRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _fieldRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _fieldRepository.FindById(idDto);
        }


        public async Task<List<FieldDto>> GetAll(string institution, bool active)
        {
            List<Field> listEnt = await _fieldRepository.GetAll(institution, active);
            List<FieldDto> listDto = _mapper.Map<List<FieldDto>>(listEnt);
            return listDto;
        }

        public async Task<FieldDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _fieldRepository.GetByCode(codeType, institucion);
            return _mapper.Map<FieldDto>(ent);
        }

        public async Task<string> GetCodeByID(int id)
        {
            var ent = await _fieldRepository.GetCodeByID(id);

            string code = ent.Code;
            return _mapper.Map<FieldDto>(ent).Code;
        }
    }
}
