using AutoMapper;
using Core.General;
using OpenDEVCore.Configuration.Dto;
using System.Collections.Generic;
using System.Linq;

namespace OpenDEVCore.Configuration.Entities
{
    public partial class Catalogue : ICoreEF
    {
        private readonly IMapper _mapper;
        public Catalogue(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Add(CatalogueDto cmnd)
        {
            Module = cmnd.Module;
            Description = cmnd.Description;
            IsActive = cmnd.IsActive;
        }

        public void Edit(CatalogueDto cmnd)
        {

            var editCtlg = _mapper.Map<Catalogue>(cmnd);

            Module = cmnd.Module;
            Description = cmnd.Description;
            IsActive = cmnd.IsActive;

            //editcio de perfiles
            foreach (var detail in CatalogueDetail)
            {
                var ctlgtmp = editCtlg.CatalogueDetail.Where(q => q.IdCatalogueDetail == detail.IdCatalogueDetail).FirstOrDefault();
                detail.Code = ctlgtmp.Code;
                detail.Description = ctlgtmp.Description;
                detail.IsActive = ctlgtmp.IsActive;
                detail.Order = ctlgtmp.Order;
            }

            //creacion de nuevos perfiles
            List<CatalogueDetail> newCatalogs = editCtlg.CatalogueDetail.Where(d => d.IdCatalogueDetail==0).ToList();

            foreach (var detail in newCatalogs)
            {
                CatalogueDetail.Add( new CatalogueDetail
                {
                Code = detail.Code,
                Description = detail.Description,
                IsActive = detail.IsActive,
                Order = detail.Order
                });
            }
        }
    }
}
