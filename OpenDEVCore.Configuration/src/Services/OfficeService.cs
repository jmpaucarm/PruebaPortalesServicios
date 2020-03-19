using AutoMapper;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Helpers;
using OpenDEVCore.Configuration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Configuration.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _iOfficeRepository;
        private readonly IMapper _mapper;
        private readonly IExMessages _iExMessages;

        public OfficeService(
        IOfficeRepository iOfficeRepository,
        IMapper mapper,
        IExMessages iExMessages
        )
        {
            _iOfficeRepository = iOfficeRepository;
            _mapper = mapper;
            _iExMessages = iExMessages;
        }

        public async Task<List<OfficeDto>> GetOffices(int[] ids)
        {
            var offs = await _iOfficeRepository.GetOffices(ids);
            return offs == null ? null : _mapper.Map<List<OfficeDto>>(offs);
        }
    }
}
