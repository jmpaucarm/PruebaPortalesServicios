using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Minio;
using Core.Mvc;
using Core.SharePoint;
using Core.Types;
using OpenDEVCore.DocBlobStorage.Dto;
using OpenDEVCore.DocBlobStorage.Entities;
using OpenDEVCore.DocBlobStorage.Helpers;
using OpenDEVCore.DocBlobStorage.Proxy;
using OpenDEVCore.DocBlobStorage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace OpenDEVCore.DocBlobStorage.Services
{
    public class DocumentService : BaseService, IDocumentService

    {
        private readonly IProxySharePoint _proxySharePoint;
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;
        private readonly ITypeDocumentService _documentService;
        private readonly IConfigurationService _configurationService;
        private readonly IExMessages _exMessages;
        private readonly IProxyMinio _proxyMinio;

        public DocumentService(
            IProxySharePoint proxySharePoint,
            IDocumentRepository documentRepository, IMapper mapper, ITypeDocumentService documentService,
            IConfigurationService configurationService, IExMessages exMessages, IProxyMinio proxyMinio
            )
            : base(configurationService)
        {
            _proxySharePoint = proxySharePoint;
            _documentRepository = documentRepository;
            _mapper = mapper;
            _documentService = documentService;
            _configurationService = configurationService;
            _exMessages = exMessages;
            _proxyMinio = proxyMinio;
        }

        public async Task<List<DocumentDto>> Add(List<DocumentDto> listDocDto, bool save)
        {
            //LLAMADA A LOS OTROS METODOS PARA RECUPERAR LA CONFIGURACION DEL DOCUMENTO

            DocumentDto singleDto = listDocDto.Last();//Extract just one  
            var listConfig = listDocDto.Select(x => x.CodeTypeDocument).ToList();
            var arrayConfig = listConfig.ToArray();

            var modifDoctypeResponse = await _documentService.GetConfigurations(singleDto.Institution, arrayConfig);
            if (!modifDoctypeResponse.state)
                _exMessages.Map(modifDoctypeResponse);
            var doctypeList = modifDoctypeResponse.Get();// list of  documentTypes

            TypeDocumentDto singleDocType = doctypeList.Last();
            var modifConfigResponse = await _configurationService.GetByCodeAsync(singleDocType.BlodStorage);

            if (!modifConfigResponse.state)
                _exMessages.Map(modifConfigResponse);
            var configType = modifConfigResponse.Get();

            //mapeo de variables si esta es  formulario debe mapear de la version activa  validar
            //en la configuracion que tenga una activa  y que solo exista una version activa
            List<DocumentDto> result = null;
            if (doctypeList.Last().IsForm == true)
            {
                result = (from DocumentDto in listDocDto
                          join TypeDocumentDto in doctypeList on DocumentDto.CodeTypeDocument equals TypeDocumentDto.Code
                          select new DocumentDto
                          {
                              CodeTypeDocument = DocumentDto.CodeTypeDocument,
                              Institution = DocumentDto.Institution,
                              Data = DocumentDto.Data,
                              DateEnd = DateTime.UtcNow.AddMonths(Convert.ToInt32(TypeDocumentDto.TimeLive)),
                              PathDocument = TypeDocumentDto.Path,
                              Iscentralized = TypeDocumentDto.IsCentrilizedOnline,
                              Type = TypeDocumentDto.Type,
                              IsVirtual = DocumentDto.IsVirtual,
                              IsActive = DocumentDto.IsActive,
                              CodeDocument = DocumentDto.CodeDocument,
                              PathDocumentFinal = "",
                              DocumentField = DocumentDto.DocumentField
                          }).ToList();


            }
            else
            {
                result = (from DocumentDto in listDocDto
                          join TypeDocumentDto in doctypeList on DocumentDto.CodeTypeDocument equals TypeDocumentDto.Code
                          select new DocumentDto
                          {
                              CodeTypeDocument = DocumentDto.CodeTypeDocument,
                              Institution = DocumentDto.Institution,
                              Data = DocumentDto.Data,
                              DateEnd = DateTime.UtcNow.AddMonths(Convert.ToInt32(TypeDocumentDto.TimeLive)),
                              PathDocument = TypeDocumentDto.Path,
                              Iscentralized = TypeDocumentDto.IsCentrilizedOnline,
                              Type = TypeDocumentDto.Type,
                              IsVirtual = DocumentDto.IsVirtual,
                              IsActive = DocumentDto.IsActive,
                              CodeDocument = DocumentDto.CodeDocument,
                              PathDocumentFinal = "",
                              DocumentField = DocumentDto.DocumentField
                          }).ToList();

            }


            string toSendRoute = configType.TextValue;
            var finalDocuments = await StoreDocument(singleDocType.BlodStorage, toSendRoute, result, singleDocType.Prefijo);

            if (save)
            {
                //foreach (var finaldoc in finalDocuments)
                //{
                //    var x = (await _documentRepository.FindByCode(finaldoc.CodeDocument, finaldoc.Institution));
                //    if (!(await _documentRepository.FindByCode(finaldoc.CodeDocument, finaldoc.Institution))){
                //        finaldoc.IsCopy = false;
                //    }

                //}
                var finalDocumentsSave = await _documentRepository.AddRange(_mapper.Map<List<Document>>(finalDocuments));
                return _mapper.Map<List<DocumentDto>>(finalDocumentsSave);
            }

            return _mapper.Map<List<DocumentDto>>(finalDocuments);
        }

        public async Task<List<DocumentNoDataDto>> GetByCodes(DocumentByCodesDto documentByCodes)
        {
            if (documentByCodes.Codes==null) {
                return new List<DocumentNoDataDto>();
            }

            var listDocuments = await _documentRepository.GetByCodes(documentByCodes.Codes, documentByCodes.Institution);
            return _mapper.Map<List<DocumentNoDataDto>>(listDocuments);
        }

        public async Task<DocumentDto> GetDocumentById(int idDto)
        {
            Document ent = await _documentRepository.GetById(idDto);
            DocumentDto dto = _mapper.Map<DocumentDto>(ent);

            var docConfigResponse = await _documentService.GetByCode(dto.CodeTypeDocument, dto.Institution);
            if (!docConfigResponse.state)
                _exMessages.Map(docConfigResponse);
            var docConfig = docConfigResponse.Get();
            string searchPath;

            try
            {
                switch (docConfig.BlodStorage)
                {
                    case "DATABASE":
                        return dto;

                    case "SHAREPOINT":
                        DtoFile dtoSharePoint = _mapper.Map<DtoFile>(dto);
                        var dataSharePoint = await _proxySharePoint.getFile(dto.PathDocumentFinal, dtoSharePoint);
                        dto.Data = dataSharePoint.data;
                        return dto;

                    case "FILESYSTEM":
                        searchPath = string.Concat(dto.PathDocumentFinal, '/', dto.CodeDocument, ".", dto.Type);
                        searchPath = (searchPath.Replace('/', '\\'));
                        dto.Data = File.ReadAllBytes(searchPath);
                        return dto;

                    case "MINIO":

                        DtoFile dtoMinio = _mapper.Map<DtoFile>(dto);
                        var dataMinio = await _proxyMinio.getFile(dto.PathDocumentFinal, dtoMinio);
                        dto.Data = dataMinio.data;
                        return dto;
                }

                return null;

            }
            catch (Exception ex)
            {
                _exMessages.StoringDocumentException.Throw(ex);
                return null;
            }


        }

        private async Task<List<DocumentDto>> StoreDocument(string storageType, string route, List<DocumentDto> listDocuments, string prefix)
        {
            try
            {
                switch (storageType)
                {
                    case "DATABASE":
                        route = "Database";
                        listDocuments.ForEach(doc => doc.PathDocumentFinal = route);
                        break;
                    case "SHAREPOINT":
                        List<DtoFile> listFiles = new List<DtoFile>();


                        foreach (var document in listDocuments)
                        {
                            var aReemplazar = document.DocumentField.Select(field => new
                            {
                                code = field.CodeField,
                                value = field.Value
                            }).ToList();

                            var path1 = document.PathDocument;
                            var pathFinal = string.Empty;

                            //validacion palabras clave
                            var spliteddPath = document.PathDocument.Split('/').ToList();
                            int numero = aReemplazar.Where(p => spliteddPath.Contains(p.code)).Count();
                            if (numero != aReemplazar.Count())
                                _exMessages.KeyWordsNotFount.Throw();

                            aReemplazar.ForEach(clave =>
                            {
                                if (clave.value != "")
                                {
                                    path1 = path1.Replace(clave.code, clave.value);
                                }


                            });

                            document.CodeDocument = string.Concat(prefix, '_', path1.Replace('/', '_'), '_', DateTime.UtcNow.ToString("yyyy-mm-dd"));
                            //string pathEnviar = path1.Substring(1, path1.Length-1);
                            document.PathDocumentFinal = path1;
                            if (document.Data != null)
                            {
                                DtoFile dtoFile = _mapper.Map<DtoFile>(document);
                                listFiles.Add(dtoFile);
                                var resultSharepoint= await _proxySharePoint.putFiles(listFiles, path1);
                                if (!resultSharepoint)
                                    _exMessages.StoringDocumentException.Throw();

                                document.Data = null;
                            }

                        };
                        break;

                    case "FILESYSTEM":
                        foreach (var dtofiles in listDocuments)
                        {
                            var aReemplazar = dtofiles.DocumentField.Select(field => new
                            {
                                code = field.CodeField,
                                value = field.Value
                            }).ToList();

                            var path1 = dtofiles.PathDocument;
                            var pathFinal = string.Empty;

                            //validacion palabras clave
                            var spliteddPath = dtofiles.PathDocument.Split('/').ToList();
                            int numero = aReemplazar.Where(p => spliteddPath.Contains(p.code)).Count();
                            if (numero != aReemplazar.Count())
                                _exMessages.KeyWordsNotFount.Throw();

                            aReemplazar.ForEach(clave =>
                            {
                                if (clave.value != "")
                                {
                                    path1 = path1.Replace(clave.code, clave.value);
                                }

                            });
                            dtofiles.CodeDocument = string.Concat(prefix, '_', path1.Replace('/', '_'), '_', DateTime.UtcNow.ToString("yyyy-mm-dd"));
                            // dtofiles.CodeDocument = string.Concat(prefix, '_', path1.Replace('/', '_'));
                            string finalRoute = string.Concat(route, "\\", path1.Replace('/', '\\'));
                            dtofiles.PathDocumentFinal = finalRoute;

                            if (dtofiles.Data != null)
                            {
                                Directory.CreateDirectory(finalRoute);
                                //File.WriteAllBytes($@"{finalRoute}\{dtofiles.CodeDocument}{dtofiles.IdDocument}.{dtofiles.Type}", dtofiles.Data);
                                File.WriteAllBytes($@"{finalRoute}\{dtofiles.CodeDocument}.{dtofiles.Type}", dtofiles.Data);
                

                                dtofiles.Data = null;
                            }
                        }
                        break;
                    case "MINIO":

                        List<DtoFile> listFilesMinio = new List<DtoFile>();

                        foreach (var document in listDocuments)
                        {


                            var aReemplazar = document.DocumentField.Select(field => new
                            {
                                code = field.CodeField,
                                value = field.Value
                            }).ToList();

                            var path1 = document.PathDocument;
                            var pathFinal = string.Empty;

                            //validacion palabras clave
                            var spliteddPath = document.PathDocument.Split('/').ToList();
                            int numero = aReemplazar.Where(p => spliteddPath.Contains(p.code)).Count();
                            if (numero != aReemplazar.Count())
                                _exMessages.KeyWordsNotFount.Throw();

                            aReemplazar.ForEach(clave =>
                            {
                                if (clave.value != "")
                                {
                                    path1 = path1.Replace(clave.code, clave.value);
                                }
                            });

                            document.CodeDocument = string.Concat(prefix, '_', path1.Replace('/', '_'), '_', DateTime.UtcNow.ToString("yyyy-mm-dd"));

                            document.PathDocumentFinal = aReemplazar[0].value;
                            if (document.Data != null)
                            {
                                DtoFile dtoFile = _mapper.Map<DtoFile>(document);
                                listFilesMinio.Add(dtoFile);


                               var resultMinio= await _proxyMinio.putFiles(listFilesMinio, aReemplazar[0].value);
                                if (!resultMinio)
                                    _exMessages.StoringDocumentException.Throw();


                                document.Data = null;
                            }

                        };



                        route = "MINIO";
                        break;
                }
                return listDocuments;
            }
            catch (Exception ex)
            {
                _exMessages.StoringDocumentException.Throw(ex);
                return null;
            }



        }

        public Task<DocumentDto> GetDocumentByCode(string codeDocument)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindByCode(string code, string institution)
        {
            return await _documentRepository.FindByCode(code, institution);
        }

        public async Task<MemoryStream> GetDocumentByType(string doctype, DocumentByCodesDto documentByCodes) {

            var documentList =await GetByCodes(documentByCodes);
            var document = documentList.LastOrDefault(doc=> doc.CodeTypeDocument.Equals(doctype));
            var documentData = await GetDocumentById(document.IdDocument);

            var fileStream = new MemoryStream(documentData.Data);
            return fileStream;
        }

   
    }
}

