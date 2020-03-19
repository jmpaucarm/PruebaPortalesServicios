using AutoMapper;
using Core.Mvc;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Repositories;

using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace OpenDevCore.DocConfiguration.Services
{
    public class TypeBoxService : BaseService, ITypeBoxService

    {
        private readonly ITypeBoxRepository _typeBoxRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;
        private readonly IFieldService _fieldService;
        private List<FieldDto> listFields;

        public TypeBoxService(ITypeBoxRepository typeBoxRepository, IMapper mapper, IExMessages iexMessages, IFieldService fieldService)

        {
            _typeBoxRepository = typeBoxRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
            _fieldService = fieldService;
        }


        public async Task<int> Add(TypeBoxDto dto)
        {
            var exists = await _typeBoxRepository.FindById(dto.IdTypeBox);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }

            //treaer la lista de todos y de ahi hacer el join a la lista  
            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeBoxField = dto.TypeBoxField;
            var genericList = (from fields in listFields
                               join typeboxFields in listTypeBoxField
                               on fields.IdField equals typeboxFields.IdField
                               select new
                               {
                                   idTypeBoxField = typeboxFields.IdTypeBoxField,
                                   idField = typeboxFields.IdField,
                                   idTypeBox = typeboxFields.IdTypeBox,
                                   isActive = typeboxFields.IsActive,
                                   isObligatory = typeboxFields.IsObligatory,
                                   order = typeboxFields.Order,
                                   codeField = fields.Code
                               }).ToList();

            for (int i = 0; i < dto.TypeBoxField.Count; i++)
            {
                dto.TypeBoxField[i].CodeField = genericList[i].codeField;
            }
            var idNewTypeBox = await _typeBoxRepository.Add(_mapper.Map<TypeBox>(dto));
            return idNewTypeBox;
        }

        public async Task<bool> Edit(TypeBoxDto dto)
        {
            var exists = await FindById(dto.IdTypeBox);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            //treaer la lista de todos y de ahi hacer el join a la lista  
            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeBoxField = dto.TypeBoxField;
            var genericList = (from fields in listFields
                               join typeboxFields in listTypeBoxField
                               on fields.IdField equals typeboxFields.IdField
                               select new
                               {
                                   idTypeBoxField = typeboxFields.IdTypeBoxField,
                                   idField = typeboxFields.IdField,
                                   idTypeBox = typeboxFields.IdTypeBox,
                                   isActive = typeboxFields.IsActive,
                                   isObligatory = typeboxFields.IsObligatory,
                                   order = typeboxFields.Order,
                                   codeField = fields.Code
                               }).ToList();

            for (int i = 0; i < dto.TypeBoxField.Count; i++)
            {
                dto.TypeBoxField[i].CodeField = genericList[i].codeField;
            }
            var entUpdate = _mapper.Map<TypeBox>(dto);
            await _typeBoxRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _typeBoxRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _typeBoxRepository.FindById(idDto);
        }

        public async Task<List<TypeBoxDto>> GetAll(string institution, bool active)
        {
            List<TypeBox> listEnt = await _typeBoxRepository.GetAll(institution, active);
            List<TypeBoxDto> listDto = _mapper.Map<List<TypeBoxDto>>(listEnt);
            return listDto;
        }

        public async Task<TypeBoxDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _typeBoxRepository.GetByCode(codeType, institucion);
            return _mapper.Map<TypeBoxDto>(ent);
        }



    }
}
