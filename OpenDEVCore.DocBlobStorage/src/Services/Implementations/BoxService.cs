using AutoMapper;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Helpers;
using OpenDEVCore.DocBlobStorage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Services
{
    public class BoxService : IBoxService
    {
        private readonly IBoxRepository _boxRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _exMessages;

        public BoxService(IBoxRepository boxRepository, IMapper mapper, IExMessages exMessages)
        {
            _boxRepository = boxRepository;
            _mapper = mapper;
            _exMessages = exMessages;
        }
        public async  Task<int> Add(BoxDto ent)
        {
            var bx = _mapper.Map<Box>(ent);
            return   await  _boxRepository.Add(bx);

        }

        public async Task<BoxDto> Edit(BoxDto ent)
        {
            var bx =await _boxRepository.Edit(_mapper.Map<Box>(ent));
            return _mapper.Map<BoxDto>(bx);
        }

        public async  Task<bool> Find(string code, string institution)
        {
            return await   _boxRepository.Find(code, institution);
        }

        public async  Task<List<BoxDto>> GetAll(string institution, bool active)
        {
            return    _mapper.Map<List<BoxDto>>( await  _boxRepository.GetAll(institution, active));
        }

        public async Task<BoxDto> GetByCode(string codeBoxDto, string institucion)
        {
            return _mapper.Map<BoxDto>(await _boxRepository.GetByCode(codeBoxDto, institucion));
        }
    }
}
