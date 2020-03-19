using AutoMapper;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Helpers;
using OpenDEVCore.DocBlobStorage.Proxy;
using OpenDEVCore.DocBlobStorage.Repositories;
using OpenDEVCore.DocBlobStorage.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.DocBlobStorage.Services.Implementations
{
    public class FolderServices : IFolderServices
    {
        private readonly IFolderRepository _folderFieldRepository;
        private readonly IMapper _mapper;



        public FolderServices(IFolderRepository folderFieldRepository,IMapper mapper)
        {
            _folderFieldRepository = folderFieldRepository;
            _mapper = mapper;
        }


        public async Task<int> Add(FolderDto entFolder)
        {
            return await _folderFieldRepository.Add(_mapper.Map<Folder>(entFolder));
             
           
        }

        public async  Task<bool> FindById(int id)
        {
           return   await _folderFieldRepository.FindById(id);

        }

        public async Task<List<FolderDto>> GetAll(string institution)
        {
            return  _mapper.Map<List<FolderDto>>(await _folderFieldRepository.GetAll(institution));
        }

        public async  Task<FolderDto> GetById(int id)
        {
            return _mapper.Map<FolderDto>(await _folderFieldRepository.GetById(id));
        }

        public async Task<FolderDto> UpdateFolder(FolderDto entFolder)
        {
            var entFol = _mapper.Map<Folder>(entFolder);
            return _mapper.Map<FolderDto>(await _folderFieldRepository.UpdateFolder(entFol));
        }
    }
}

