using Core.Mvc;
using Core.Types;
using OpenDEVCore.Api.Dtos;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OpenDEVCore.Api.Services
{

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDocConfiguration :IProxy
    {
        #region Field
        [AllowAnyStatusCode]
        [Get("Field/GetAll")]
        Task<CoreResponse<List<FieldDto>>> GetAllField([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Get("Field/findbycodes")]
        Task<CoreResponse<bool>> FindByCodesField([Query]string institution, [Body] List<string> codes);

        [AllowAnyStatusCode]
        [Post("Field/Add")]
        Task<CoreResponse<int>> AddField([Body]FieldDto FieldDto);

        [AllowAnyStatusCode]
        [Get("Field/GetByCode")]
        Task<CoreResponse<FieldDto>> GetByCodeField([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("Field/Find")]
        Task<CoreResponse<bool>> FindField([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("Field/Edit")]
        Task<CoreResponse<bool>> EditField([Body]FieldDto FieldDto);
        #endregion

        #region TypeBox

        [AllowAnyStatusCode]
        [Get("TypeBox/GetAll")]
        Task<CoreResponse<List<TypeBoxDto>>> GetAllTypeBox([Query]string institution, [Query]bool active);


        [AllowAnyStatusCode]
        [Post("TypeBox/Add")]
        Task<CoreResponse<int>> AddTypeBox([Body]TypeBoxDto TypeBoxDto);

        [AllowAnyStatusCode]
        [Get("TypeBox/GetByCode")]
        Task<CoreResponse<FieldDto>> GetByCodeTypeBox([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeBox/Find")]
        Task<CoreResponse<bool>> FindTypeBox([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("TypeBox/Edit")]
        Task<CoreResponse<bool>> EditTypeBox([Body]TypeBoxDto TypeBoxDto);

        #endregion

        #region TypeDocument

        [AllowAnyStatusCode]
        [Get("TypeDocument/GetAll")]
        Task<CoreResponse<List<TypeDocumentDto>>> GetAllTypeDocument([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Get("TypeDocument/findbycodes")]
        Task<CoreResponse<bool>> FindByCodesTypeDocument([Query]string institution, [Body] List<string> codes);

        [AllowAnyStatusCode]
        [Post("TypeDocument/Add")]
        Task<CoreResponse<int>> AddTypeDocument([Body]TypeDocumentDto typeDocumentDto);

        [AllowAnyStatusCode]
        [Get("TypeDocument/GetByCode")]
        Task<CoreResponse<TypeDocumentDto>> GetByCodeTypeDocument([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeDocument/Find")]
        Task<CoreResponse<bool>> FindTypeDocument([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeDocument/getconfigurations")]
        Task<CoreResponse<List<TypeDocumentDto>>> GetConfigurations([Query]string institution, [Query] string[] codes);
        
        [AllowAnyStatusCode]
        [Put("TypeDocument/edit")]
        Task<CoreResponse<List<TypeDocumentDto>>> Edit([Body]TypeDocumentDto typeDocumentDto);

        [AllowAnyStatusCode]
        [Get("TypeDocument/getAllForm")]
        Task<CoreResponse<List<TypeDocumentDto>>> GetAllForm([Query]string institution, [Query]bool isForm);
        #endregion

        #region TypeFolder
        [AllowAnyStatusCode]
        [Get("TypeFolder/GetAll")]
        Task<CoreResponse<List<TypeFolderDto>>> GetAllTypeFolder([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Post("TypeFolder/Add")]
        Task<CoreResponse<int>> AddTypeFolder([Body]TypeFolderDto TypeFolderDto);

        [AllowAnyStatusCode]
        [Get("TypeFolder/GetByCode")]
        Task<CoreResponse<TypeFolderDto>> GetByCodeTypeFolder([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeFolder/Find")]
        Task<CoreResponse<bool>> FindTypeFolder([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("TypeFolder/Edit")]
        Task<CoreResponse<bool>> EditTypeFolder([Body]TypeFolderDto TypeFolderDto);

        #endregion

        #region TypeImage
        [AllowAnyStatusCode]
        [Get("TypeImage/GetAll")]
        Task<CoreResponse<List<TypeImageDto>>> GetAllTypeImage([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Post("TypeImage/Add")]
        Task<CoreResponse<int>> AddTypeImage([Body]TypeImageDto TypeImageDto);

        [AllowAnyStatusCode]
        [Get("TypeImage/GetByCode")]
        Task<CoreResponse<TypeImageDto>> GetByCodeTypeImage([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("TypeImage/Find")]
        Task<CoreResponse<bool>> FindTypeImage([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("TypeImage/Edit")]
        Task<CoreResponse<bool>> EditTypeImage([Body]TypeImageDto TypeImageDto);

        #endregion

        #region FormVersion

        [AllowAnyStatusCode]
        [Get("FormVersion/GetAll")]
        Task<CoreResponse<List<TypeImageDto>>> GetAllFormVersion([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Post("FormVersion/Add")]
        Task<CoreResponse<int>> AddFormVersion([Body]FormVersionDto TypeImageDto);

        [AllowAnyStatusCode]
        [Get("FormVersion/GetByCode")]
        Task<CoreResponse<TypeImageDto>> GetByCodeFormVersion([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("FormVersion/Find")]
        Task<CoreResponse<bool>> FindFormVersion([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("FormVersion/Edit")]
        Task<CoreResponse<bool>> EditFormVersion([Body]FormVersionDto TypeImageDto);

        #endregion

        #region WaterMark
        [AllowAnyStatusCode]
        [Get("WaterMark/GetAll")]
        Task<CoreResponse<List<TypeImageDto>>> GetAllWaterMark([Query]string institution, [Query]bool active);

        [AllowAnyStatusCode]
        [Post("WaterMark/Add")]
        Task<CoreResponse<int>> AddWaterMark([Body]WaterMarkDto TypeImageDto);

        [AllowAnyStatusCode]
        [Get("WaterMark/GetByCode")]
        Task<CoreResponse<TypeImageDto>> GetByCodeWaterMark([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Get("WaterMark/Find")]
        Task<CoreResponse<bool>> FindWaterMark([Query]string code, [Query] string institution);

        [AllowAnyStatusCode]
        [Put("WaterMark/Edit")]
        Task<CoreResponse<bool>> EditWaterMark([Body]WaterMarkDto TypeImageDto);
        #endregion
    }
}
