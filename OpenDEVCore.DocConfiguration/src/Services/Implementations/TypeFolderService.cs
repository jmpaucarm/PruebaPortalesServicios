using AutoMapper;
using Core.Mvc;
using OpenDevCore.DocConfiguration.Dto;
using OpenDevCore.DocConfiguration.Helpers;
using OpenDevCore.DocConfiguration.Repositories;

using OpenDevCore.DocConfiguration.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OpenDevCore.DocConfiguration.Services
{
    public class TypeFolderService : BaseService, ITypeFolderService
    {
        private readonly ITypeFolderRepository _typeFolderRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;
        private readonly IFieldService _fieldService;
        private List<FieldDto> listFields;

        public TypeFolderService(ITypeFolderRepository typeFolderRepository, IMapper mapper, IExMessages iexMessages, IFieldService fieldService)
        {
            _typeFolderRepository = typeFolderRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
            _fieldService = fieldService;
        }


        public async Task<int> Add(TypeFolderDto dto)
        {
            var exists = await _typeFolderRepository.FindById(dto.IdTypeFolder);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }
            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeFolderField = dto.TypeFolderField;
            var genericList = (from fields in listFields
                               join typeDctoFields in listTypeFolderField
                               on fields.IdField equals typeDctoFields.IdField
                               select new
                               {
                                   idTypeFolderField = typeDctoFields.IdTypeFolderField,
                                   idField = typeDctoFields.IdField,
                                   idTypeFolder = typeDctoFields.IdTypeFolder,
                                   isActive = typeDctoFields.IsActive,
                                   isObligatory = typeDctoFields.IsObligatory,
                                   order = typeDctoFields.Order,
                                   codeField = fields.Code
                               }).ToList();
            for (int i = 0; i < dto.TypeFolderField.Count; i++)
            {
                dto.TypeFolderField[i].CodeField = genericList[i].codeField;
            }
            var idNewTypeFolder = await _typeFolderRepository.Add(_mapper.Map<TypeFolder>(dto));
            return idNewTypeFolder;
        }

        public async Task<bool> Edit(TypeFolderDto dto)
        {
            var exists = await FindById(dto.IdTypeFolder);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            listFields = _fieldService.GetAll(dto.Institution, true).Result;
            var listTypeFolderField = dto.TypeFolderField;
            var genericList = (from fields in listFields
                               join typeDctoFields in listTypeFolderField
                               on fields.IdField equals typeDctoFields.IdField
                               select new
                               {
                                   idTypeFolderField = typeDctoFields.IdTypeFolderField,
                                   idField = typeDctoFields.IdField,
                                   idTypeFolder = typeDctoFields.IdTypeFolder,
                                   isActive = typeDctoFields.IsActive,
                                   isObligatory = typeDctoFields.IsObligatory,
                                   order = typeDctoFields.Order,
                                   codeField = fields.Code
                               }).ToList();
            for (int i = 0; i < dto.TypeFolderField.Count; i++)
            {
                dto.TypeFolderField[i].CodeField = genericList[i].codeField;
            }
            var entUpdate = _mapper.Map<TypeFolder>(dto);
            await _typeFolderRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _typeFolderRepository.Find(code, institution);
        }


        public async Task<bool> FindById(int idDto)
        {
            return await _typeFolderRepository.FindById(idDto);
        }

        public async Task<List<TypeFolderDto>> GetAll(string institution, bool active)
        {
            List<TypeFolder> listEnt = await _typeFolderRepository.GetAll(institution, active);
            List<TypeFolderDto> listDto = _mapper.Map<List<TypeFolderDto>>(listEnt);
            return listDto;
        }

        public async Task<TypeFolderDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _typeFolderRepository.GetByCode(codeType, institucion);
            return (ent == null) ? new TypeFolderDto() : _mapper.Map<TypeFolderDto>(ent);
        }
    }
}
