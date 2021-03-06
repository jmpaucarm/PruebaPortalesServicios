﻿using System;
using System.Collections.Generic;

namespace OpenDevCore.DocConfiguration.Entities
{
    public partial class Field
    {
        public Field()
        {
            TypeBoxField = new HashSet<TypeBoxField>();
            TypeDctoField = new HashSet<TypeDctoField>();
            TypeFolderField = new HashSet<TypeFolderField>();
        }

        public int IdField { get; set; }
        public string Code { get; set; }
        public string Institution { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public short? Length { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreationUserId { get; set; }
        public int? CreationOfficeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public int? UpdateOfficeId { get; set; }

        public virtual ICollection<TypeBoxField> TypeBoxField { get; set; }
        public virtual ICollection<TypeDctoField> TypeDctoField { get; set; }
        public virtual ICollection<TypeFolderField> TypeFolderField { get; set; }
    }
}
