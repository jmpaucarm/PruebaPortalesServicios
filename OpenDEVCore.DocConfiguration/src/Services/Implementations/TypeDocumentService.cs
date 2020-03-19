using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OpenDevCore.DocConfiguration.Entities;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Repositories;
using Core.Mvc;

using System.Linq;

namespace OpenDevCore.DocConfiguration.Services
{
    public class TypeDocumentService : BaseService, ITypeDocumentService
    {
        private readonly ITypeDocumentRepository _typeDocumentRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;
        private readonly IFieldService _fieldService;
        private List<FieldDto> listFields;

        public TypeDocumentService(ITypeDocumentRepository typeDocumentRepository, IMapper mapper, IExMessages iexMessages, IFieldService fieldService)

        {
            _typeDocumentRepository = typeDocumentRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
            _fieldService = fieldService;
        }

        public async Task<int> Add(TypeDocumentDto dto)
        {
            var exists = await _typeDocumentRepository.FindById(dto.IdTypeDocument);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }

            //treaer la lista de todos y de ahi hacer el join a la lista

            

            if (dto.TypeDctoField==null)
                _iexMessages.SendFieldsError.Throw();

            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeDctoField = dto.TypeDctoField;
            var genericList = (from fields in listFields
                               join typeDctoFields in listTypeDctoField
                               on fields.IdField equals typeDctoFields.IdField
                               select new
                               {
                                   idTypeDctoField = typeDctoFields.IdTypeDctoField,
                                   idField = typeDctoFields.IdField,
                                   idTypeBox = typeDctoFields.IdTypeDocument,
                                   isActive = typeDctoFields.IsActive,
                                   isObligatory = typeDctoFields.IsObligatory,
                                   order = typeDctoFields.Order,
                                   codeField = fields.Code
                               }).ToList();

            for (int i = 0; i < dto.TypeDctoField.Count; i++)
            {
                dto.TypeDctoField[i].CodeField = genericList[i].codeField;
            }
            var listKeyWords = dto.TypeDctoField.OrderBy(p => p.Order).ToList();

            var pathPartial = string.Empty;
            listKeyWords.ForEach(lkw =>
            {
                pathPartial = string.Concat(pathPartial, '/', lkw.CodeField);
            });

            string pathFinal = pathPartial.Substring(1, pathPartial.Length - 1);
            dto.Path = pathFinal;

            var idNewTypeDocument = await _typeDocumentRepository.Add(_mapper.Map<TypeDocument>(dto));
            return idNewTypeDocument;
        }

        public async Task<bool> Edit(TypeDocumentDto dto)
        {
            var exists = await FindById(dto.IdTypeDocument);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();

            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeDctoField = dto.TypeDctoField;
            var genericList = (from fields in listFields
                               join typeDctoFields in listTypeDctoField
                               on fields.IdField equals typeDctoFields.IdField
                               select new
                               {
                                   idTypeDctoField = typeDctoFields.IdTypeDctoField,
                                   idField = typeDctoFields.IdField,
                                   idTypeBox = typeDctoFields.IdTypeDocument,
                                   isActive = typeDctoFields.IsActive,
                                   isObligatory = typeDctoFields.IsObligatory,
                                   order = typeDctoFields.Order,
                                   codeField = fields.Code
                               }).ToList();
            for (int i = 0; i < dto.TypeDctoField.Count; i++)
            {
                dto.TypeDctoField[i].CodeField = genericList[i].codeField;
            }
            var entUpdate = _mapper.Map<TypeDocument>(dto);
            await _typeDocumentRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _typeDocumentRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _typeDocumentRepository.FindById(idDto);
        }


        public async Task<List<TypeDocumentDto>> GetAll(string institution, bool active)
        {
            List<TypeDocument> listEnt = await _typeDocumentRepository.GetAll(institution, active);
            List<TypeDocumentDto> listDto = _mapper.Map<List<TypeDocumentDto>>(listEnt);
            return listDto;
        }

        public async Task<List<TypeDocumentDto>> GetAllForm(string institution, bool isForm)
        {
            List<TypeDocument> listEnt = await _typeDocumentRepository.GetAllForm(institution, isForm);
            List<TypeDocumentDto> listDto = _mapper.Map<List<TypeDocumentDto>>(listEnt);
            return listDto;
        }

        public async Task<TypeDocumentDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _typeDocumentRepository.GetByCode(codeType, institucion);
            if (ent == null)
                _iexMessages.EntityDoesNotExists.Throw();
            return _mapper.Map<TypeDocumentDto>(ent);

        }

        public async Task<List<TypeDocumentDto>> GetConfigurations(List<string> codigos, string institucion)
        {
            var lista = await _typeDocumentRepository.GetConfigurations(codigos, institucion);
            return _mapper.Map<List<TypeDocumentDto>>(lista);
        }
    }
}
