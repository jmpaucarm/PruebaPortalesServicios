using AutoMapper;
using Core.Types;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OpenDEVCore.Security.Helpers;

namespace OpenDEVCore.Security.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ISecurityRepository _securityRepository;
        private readonly IMapper _mapper;

        public ProfileService(
            IProfileRepository profileRepository,
            ISecurityRepository securityRepository,
            IMapper mapper
           )
        {
            _profileRepository = profileRepository;
            _securityRepository = securityRepository;
            _mapper = mapper;
        }

        public async Task<List<ProfileDto>> GetAllAsync()
        {
            var profiles = await _profileRepository.GetAllAsync();
            return profiles == null ? null : _mapper.Map<List<ProfileDto>>(profiles);

            //List<ProfileDto> listProfiles = new List<ProfileDto>();
            //foreach (var p in profiles)
            //{
            //    listProfiles.Add( new ProfileDto {
            //        IdProfile = p.IdProfile,
            //        ProfileCode = p.ProfileCode,
            //        Name = p.Name,
            //        DateValidity = new DateTimeOffset(p.DateValidity.Value, new TimeSpan(0, 0, 0)).ToUnixTimeSeconds(),
            //        IsActive = p.IsActive,
            //        IsGeneral = p.IsGeneral,
            //        Channel = p.Channel
            //    }
            //    );
            //}
            //return listProfiles;
        }

        public async Task<ProfileDto> GetByIdAsync(int id)
        {
            var ctlg = await _profileRepository.GetByIdAsync(id);
            return ctlg == null ? null : _mapper.Map<ProfileDto>(ctlg);
        }

        public async Task<bool> FindByCodeAsync(string code, int idInstitution)
        {
            var ctlg = await _profileRepository.FindAsync(code, idInstitution);
            return ctlg;
        }
        public async Task<ProfileDto> GetByCodeInstitutionAsync(string code, int idInstitution)
        {
            var data = await _profileRepository.GetByCodeInstitutionAsync(code, idInstitution);
            return data == null ? null : _mapper.Map<ProfileDto>(data);
        }
        public async Task<bool> EditAsync(EditProfileDto profileDto)
        {
            var exist = await _profileRepository.FindAsync(profileDto.ProfileCode, profileDto.IdInstitution);
            if (!exist)
                throw new CoreException(ExMessages.EntityDoesNotExists);

            var profile = _mapper.Map<Entities.Profile>(profileDto);

            _profileRepository.Edit(profile);
            return await _securityRepository.SaveAsync();

        }
        public async Task<int> AddAsync(AddProfileDto profileDto)
        {
            var exist = await _profileRepository.FindAsync(profileDto.ProfileCode, profileDto.IdInstitution);
            if (exist)// valid que el registro exista
                throw new CoreException(ExMessages.EntityAllreadyExists);

            //crea el ef de catalogo
            var newProfile = _mapper.Map<Entities.Profile>(profileDto);

            //crea el registro en la tabla
            await _profileRepository.AddAsync(newProfile);

            //commit en la base de datos
            await _securityRepository.SaveAsync();
            return newProfile.IdProfile;
        }
    }
}
