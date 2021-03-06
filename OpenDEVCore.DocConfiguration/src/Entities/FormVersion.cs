﻿using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class FormVersion
    {
        public int IdFormVersion { get; set; }
        public int? IdTypeDocument { get; set; }
        public int? IdWaterMark { get; set; }
        public bool IsWaterMarked { get; set; }
        public byte[] Template { get; set; }
        public bool? IsActive { get; set; }
        
        public DateTime StartValidityDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Institution { get; set; }
        public DateTime? EndValidityDate { get; set; }
        public string Module { get; set; }
        public string CodeSP { get; set; }

        public virtual TypeDocument IdTypeDocumentNavigation { get; set; }
        public virtual WaterMark IdWaterMarkNavigation { get; set; }
    }
}
