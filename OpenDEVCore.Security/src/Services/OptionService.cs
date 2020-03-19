using AutoMapper;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        public OptionService(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

     
        public async Task<List<OptionDto>> GetAllAsync()
        {
            var data = await _optionRepository.GetAllAsync();
            return data == null ? null : _mapper.Map<List<OptionDto>>(data);
        }

 
    }
}
