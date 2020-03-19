using AutoMapper;
using Core.Types;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Entities;
using OpenDEVCore.Security.Helpers;
using OpenDEVCore.Security.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Security.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository menuRepository, ISecurityRepository securityRepository, IOptionRepository optionRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _securityRepository = securityRepository;
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MenuDto menuDto)
        {
            var exist = await _menuRepository.GetByIdAsync(menuDto.IdMenu);
            if (exist != null)
                throw new CoreException(ExMessages.EntityAllreadyExists);

            var newMenu = _mapper.Map<Menu>(menuDto);

            await _menuRepository.AddAsync(newMenu);

            await _securityRepository.SaveAsync();

            if (newMenu.Level == "SCREEN")
            {
                await _optionRepository.AddAsync(new Option
                {
                    IdOption = 0,
                    IdMenu = newMenu.IdMenu,
                    Type = "VIEW",
                    DashBoard = string.Empty,
                    Url = string.Empty,
                    Report = string.Empty,
                    IsAdministrative = false,
                    View = newMenu.Name
                });

                await _securityRepository.SaveAsync();
            }

            return newMenu.IdMenu;
        }

        public async Task<bool> EditAsync(MenuDto menuDto)
        {
            var exist = await _menuRepository.GetByIdAsync(menuDto.IdMenu);
            if (exist == null)
                throw new CoreException(ExMessages.EntityDoesNotExists);

            var menu = _mapper.Map<Menu>(menuDto);

            _menuRepository.Edit(menu);
            return await _securityRepository.SaveAsync();
        }

        public async Task<List<MenuDto>> GetAllAsync()
        {
            var data = await _menuRepository.GetAllAsync();
            return data == null ? null : _mapper.Map<List<MenuDto>>(data);
        }

        public async Task<List<MenuDto>> GetAllScreensAsync()
        {
            var data = await _menuRepository.GetAllScreensAsync();
            return data == null ? null : _mapper.Map<List<MenuDto>>(data);
        }
    }
}
