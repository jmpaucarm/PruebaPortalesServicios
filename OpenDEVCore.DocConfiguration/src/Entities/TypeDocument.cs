using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class TypeDocument
    {
        public TypeDocument()
        {
            Area = new HashSet<Area>();
            AreaOcr = new HashSet<AreaOcr>();
            FormVersion = new HashSet<FormVersion>();
            TypeDctoField = new HashSet<TypeDctoField>();
            TypeDctoFolder = new HashSet<TypeDctoFolder>();
        }

        public int IdTypeDocument { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Prefijo { get; set; }
        public bool? IsDigitizable { get; set; }
        public bool? IsCentrilizedOnline { get; set; }
        public int? IdTypeImage { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string BlodStorage { get; set; }
        public string Profile { get; set; }
        public short? TimeLive { get; set; }
        public bool? IsVirtual { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsForm { get; set; }
        public bool? IsScanLote { get; set; }
        public int? IdTypeForm { get; set; }
        public int? CreationUserId { get; set; }
        public string Orientation { get; set; }
        public bool ValuedDocument { get; set; }
        public short CopyNumber { get; set; }
        public bool? Reprintable { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual TypeDctoProfile TypeDctoProfile { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<AreaOcr> AreaOcr { get; set; }
        public virtual ICollection<FormVersion> FormVersion { get; set; }
        public virtual ICollection<TypeDctoField> TypeDctoField { get; set; }
        public virtual ICollection<TypeDctoFolder> TypeDctoFolder { get; set; }
    }
}
