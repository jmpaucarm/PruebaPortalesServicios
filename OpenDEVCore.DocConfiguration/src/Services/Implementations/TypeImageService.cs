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
    public class TypeImageService : BaseService, ITypeImageService
    {
        private readonly ITypeImageRepository _TypeImageRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iexMessages;

        public TypeImageService(ITypeImageRepository TypeImageRepository, IMapper mapper, IExMessages iexMessages)

        {
            _TypeImageRepository = TypeImageRepository;
            _mapper = mapper;
            _iexMessages = iexMessages;
        }
        public async Task<int> Add(TypeImageDto dto)
        {
            var exists = await _TypeImageRepository.FindById(dto.IdTypeImage);
            if (exists)
            {
                _iexMessages.EntityAllreadyExists.Throw();
            }
            var idNewTypeImage = await _TypeImageRepository.Add(_mapper.Map<TypeImage>(dto));
            return idNewTypeImage;
        }

        public async Task<bool> Edit(TypeImageDto dto)
        {
            var exists = await FindById(dto.IdTypeImage);
            if (!exists)
                _iexMessages.EntityDoesNotExists.Throw();
            var entUpdate = _mapper.Map<TypeImage>(dto);
            await _TypeImageRepository.Edit(entUpdate);
            return true;
        }

        public async Task<bool> Find(string code, string institution)
        {
            return await _TypeImageRepository.Find(code, institution);
        }

        public async Task<bool> FindById(int idDto)
        {
            return await _TypeImageRepository.FindById(idDto);
        }

        public async Task<List<TypeImageDto>> GetAll(string institution, bool active)
        {
            List<TypeImage> listEnt = await _TypeImageRepository.GetAll(institution, active);
            List<TypeImageDto> listDto = _mapper.Map<List<TypeImageDto>>(listEnt);
            return listDto;
        }

        public async Task<TypeImageDto> GetByCode(string codeType, string institucion)
        {
            var ent = await _TypeImageRepository.GetByCode(codeType, institucion);
            return (ent == null) ? new TypeImageDto() : _mapper.Map<TypeImageDto>(ent);
        }
    }
}
