using Core.Mvc;
using Core.Types;
using OpenDEVCore.Api.Dtos;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Services
{

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IBlobStorageService:IProxy
    {
        #region Document

        [AllowAnyStatusCode]
        [Post("Document/savedocuments")]
        Task<CoreResponse<List<DocumentDto>>> SaveDocuments([Body] AddDocumentsDto parametros);

        [AllowAnyStatusCode]
        [Get("Document/getdocumentbyid")]
        Task<CoreResponse<DocumentDto>> GetDocumentById([Query] int idDocument);

        [AllowAnyStatusCode]
        [Get("Document/getdocumetnodata")]
        Task<CoreResponse<List<DocumentNoDataDto>>> GetDocumetNoData([Query] string[] codes, [Query] string institution);
                     
        #endregion

    }
}
