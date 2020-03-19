using Core.Mvc;
using Core.Types;
using OpenDEVCore.Configuration.Dto;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenDEVCore.Api.Services
{
    /// <summary>
    /// Configuration interface
    /// </summary>
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
   
    public interface IConfigurationService : IProxy
    {

        #region CATALOGOS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("catalogue/getcatalogsbycodes")]
        Task<CoreResponse> GetCatalogsByCodes([Query] string query, [Query] int idInstitution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("catalogue/getcataloguebycode")]
        Task<CoreResponse> GetCatalogueByCode([Query] string query, [Query] int idInstitution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("catalogue/getcataloguebyid")]
        Task<CoreResponse> GetCatalogueById([Query] int id, [Query] int idInstitution);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("catalogue/getallcatalogs")]
        Task<CoreResponse> GetAllCatalogs();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("catalogue/addcatalogue")]
        Task<CoreResponse> PostAsync([Body]AddCatalogueDto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("catalogue/editcatalogue")]
        Task<CoreResponse> PostAsync([Body]EditCatalogueDto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="idInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("catalogue/findcataloguebycode")]
        Task<CoreResponse> FindCatalogueByCode([Query] string code, [Query] int idInstitution);




        #endregion

        #region INSTITUCIONES
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("institution/getinstitutionbyid")]
        Task<CoreResponse> GetInstitutionById([Query] int id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("institution/getinstitutionbycode")]
        Task<CoreResponse> GetInstitutionByCode([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onlyActive"></param>
        /// <param name="onlyInstitution"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("institution/getallinstitutions")]
        Task<CoreResponse> GetAllInstitutions([Query] bool onlyActive, [Query] bool onlyInstitution);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("institution/addinstitution")]
        Task<CoreResponse> PostAsync([Body]AddInstitutionDto institution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="institution"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("institution/editinstitution")]
        Task<CoreResponse> PostAsync([Body]EditInstitutionDto institution);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("institution/findinstitutionbyruc")]
        Task<CoreResponse> FindInstitutionByRuc([Query] string ruc);

        #endregion

        #region PARAMETER
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("parameter/getparameterbyid")]
        Task<CoreResponse> GetParameterById([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("parameter/getparameterbycode")]
        Task<CoreResponse> GetParameterByCode([Query] string code);

        /// <summary>
        /// /
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("parameter/findparameter")]
        Task<CoreResponse> FindParameter([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("parameter/getallparameters")]
        Task<CoreResponse> GetAllParameters();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("parameter/addparameter")]
        Task<CoreResponse> PostAsync([Body]AddParameterDto parameter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("parameter/editparameter")]
        Task<CoreResponse> PostAsync([Body]EditParameterDto parameter);

        #endregion


        #region HOLIDAY
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("holiday/getholidaybyid")]
        Task<CoreResponse> GetHolidayById([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holidayDate"></param>
        /// <param name="idUbication"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("holiday/getholidaybydate")]
        Task<CoreResponse> GetHolidayByDate([Query] long holidayDate, [Query] int idUbication);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="holidayDate"></param>
        /// <param name="idUbication"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("holiday/findholiday")]
        Task<CoreResponse> FindHolidayByDate([Query] long holidayDate, [Query] int idUbication);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("holiday/getallholidays")]
        Task<CoreResponse> GetAllHolidays();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holiday"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("holiday/addholiday")]
        Task<CoreResponse> PostAsync([Body]AddHolidayDto holiday);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="holiday"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("holiday/editholiday")]
        Task<CoreResponse> PostAsync([Body]EditHolidayDto holiday);

        #endregion

        #region UBICACION GEOGRAFICA1
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation1")]
        Task<CoreResponse> GetAllLocation1();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbycodelocation1")]
        Task<CoreResponse> GetByCodeLocation1([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbyidlocation1")]
        Task<CoreResponse> GetByIdLocation1([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/addlocation1")]
        Task<CoreResponse> PostAsync([Body]AddGeographicLocation1Dto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/editlocation1")]
        Task<CoreResponse> PostAsync([Body]EditGeographicLocation1Dto ctlgo);

        #endregion

        #region UBICACION GEOGRAFICA2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation2")]
        Task<CoreResponse> GetAllLocation2([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation2ByCode")]
        Task<CoreResponse> GetAllLocation2ByCode([Query] string code);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getallonlylocation2")]
        Task<CoreResponse> GetAllOnlyLocation2();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbycodelocation2")]
        Task<CoreResponse> GetByCodeLocation2([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbyidlocation2")]
        Task<CoreResponse> GetByIdLocation2([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/addlocation2")]
        Task<CoreResponse> PostAsync([Body]AddGeographicLocation2Dto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/editlocation2")]
        Task<CoreResponse> PostAsync([Body]EditGeographicLocation2Dto ctlgo);

        #endregion


        #region UBICACION GEOGRAFICA3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation3")]
        Task<CoreResponse> GetAllLocation3([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation3ByCode")]
        Task<CoreResponse> GetAllLocation3ByCode([Query] string code);

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbycodelocation3")]
        Task<CoreResponse> GetByCodeLocation3([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbyidlocation3")]
        Task<CoreResponse> GetByIdLocation3([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/addlocation3")]
        Task<CoreResponse> PostAsync([Body]AddGeographicLocation3Dto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/editlocation3")]
        Task<CoreResponse> PostAsync([Body]EditGeographicLocation3Dto ctlgo);

        #endregion

        #region UBICACION GEOGRAFICA4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation4")]
        Task<CoreResponse> GetAllLocation4([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getalllocation4ByCode")]
        Task<CoreResponse> GetAllLocation4ByCode([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbycodelocation4")]
        Task<CoreResponse> GetByCodeLocation4([Query] string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Get("ubication/getbyidlocation4")]
        Task<CoreResponse> GetByIdLocation4([Query] int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/addlocation4")]
        Task<CoreResponse> PostAsync([Body]AddGeographicLocation4Dto ctlgo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctlgo"></param>
        
        /// <returns></returns>
        [AllowAnyStatusCode]
        [Post("ubication/editlocation4")]
        Task<CoreResponse> PostAsync([Body]EditGeographicLocation4Dto ctlgo);

        #endregion

    }
}
