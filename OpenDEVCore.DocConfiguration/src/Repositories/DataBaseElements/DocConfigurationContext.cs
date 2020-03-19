using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenDevCore.DocConfiguration.Entities;

namespace OpenDevCore.DocConfiguration
{
    public partial class DocConfigurationContext : DbContext
    {
        public DocConfigurationContext()
        {
        }

        public DocConfigurationContext(DbContextOptions<DocConfigurationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AreaOcr> AreaOcr { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<FormVersion> FormVersion { get; set; }
        public virtual DbSet<TypeBox> TypeBox { get; set; }
        public virtual DbSet<TypeBoxField> TypeBoxField { get; set; }
        public virtual DbSet<TypeDctoField> TypeDctoField { get; set; }
        public virtual DbSet<TypeDctoFolder> TypeDctoFolder { get; set; }
        public virtual DbSet<TypeDctoProfile> TypeDctoProfile { get; set; }
        public virtual DbSet<TypeDocument> TypeDocument { get; set; }
        public virtual DbSet<TypeFolder> TypeFolder { get; set; }
        public virtual DbSet<TypeFolderField> TypeFolderField { get; set; }
        public virtual DbSet<TypeImage> TypeImage { get; set; }
        public virtual DbSet<WaterMark> WaterMark { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK_AREA");

                entity.HasIndex(e => new { e.Code, e.IdTypeDocument })
                    .HasName("IX_Area")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IdNewTypeDocument).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tall).HasDefaultValueSql("((0))");

                entity.Property(e => e.Wide).HasDefaultValueSql("((0))");

                entity.Property(e => e.X).HasDefaultValueSql("((0))");

                entity.Property(e => e.Y).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.IdTypeDocument)
                    .HasConstraintName("FK_AREA_REFERENCE_TYPEDOCU");
            });

            modelBuilder.Entity<AreaOcr>(entity =>
            {
                entity.HasKey(e => e.IdAreaOcr)
                    .HasName("PK_AREAOCR");

                entity.HasIndex(e => new { e.Code, e.IdTypeDocument })
                    .HasName("IX_AreaOcr")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Tall).HasDefaultValueSql("((0))");

                entity.Property(e => e.Wide).HasDefaultValueSql("((0))");

                entity.Property(e => e.X).HasDefaultValueSql("((0))");

                entity.Property(e => e.Y).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.AreaOcr)
                    .HasForeignKey(d => d.IdTypeDocument)
                    .HasConstraintName("FK_AREAOCR_REFERENCE_TYPEDOCU");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.HasKey(e => e.IdField)
                    .HasName("PK_FIELD");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_Field")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Length).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<FormVersion>(entity =>
            {
                entity.HasKey(e => e.IdFormVersion)
                    .HasName("PK_FORMVERSION");

                entity.HasIndex(e => new { e.IdTypeDocument, e.StartValidityDate })
                    .HasName("IX_FormVersion");

                entity.Property(e => e.Code)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CodeSP)
              .HasMaxLength(64)
              .IsUnicode(false);

                entity.Property(e => e.Module)
              .HasMaxLength(16)
              .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.EndValidityDate).HasColumnType("datetime");

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.StartValidityDate).HasColumnType("datetime");

                entity.Property(e => e.Template).IsRequired();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.FormVersion)
                    .HasForeignKey(d => d.IdTypeDocument)
                    .HasConstraintName("FK_FORMVERS_REFERENCE_TYPEDOCU");

                entity.HasOne(d => d.IdWaterMarkNavigation)
                    .WithMany(p => p.FormVersion)
                    .HasForeignKey(d => d.IdWaterMark)
                    .HasConstraintName("FK_FORMVERS_REFERENCE_WATERMAR");
            });

            modelBuilder.Entity<TypeBox>(entity =>
            {
                entity.HasKey(e => e.IdTypeBox)
                    .HasName("PK_TYPEBOX");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_TypeBox")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<TypeBoxField>(entity =>
            {
                entity.HasKey(e => e.IdTypeBoxField)
                    .HasName("PK_TYPEBOXFIELD");

                entity.HasIndex(e => new { e.IdTypeBox, e.CodeField })
                    .HasName("IX_TypeBoxField")
                    .IsUnique();

                entity.Property(e => e.CodeField)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConstant).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsObligatory).HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdFieldNavigation)
                    .WithMany(p => p.TypeBoxField)
                    .HasForeignKey(d => d.IdField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEBOXF_REFERENCE_FIELD");

                entity.HasOne(d => d.IdTypeBoxNavigation)
                    .WithMany(p => p.TypeBoxField)
                    .HasForeignKey(d => d.IdTypeBox)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEBOXF_REFERENCE_TYPEBOX");
            });

            modelBuilder.Entity<TypeDctoField>(entity =>
            {
                entity.HasKey(e => e.IdTypeDctoField)
                    .HasName("PK_TYPEDCTOFIELD");

                entity.HasIndex(e => new { e.IdTypeDocument, e.CodeField })
                    .HasName("IX_TypeDctoField")
                    .IsUnique();

                entity.Property(e => e.CodeField)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConstant).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsObligatory).HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdFieldNavigation)
                    .WithMany(p => p.TypeDctoField)
                    .HasForeignKey(d => d.IdField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEDCTO_REFERENCE_FIELD");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.TypeDctoField)
                    .HasForeignKey(d => d.IdTypeDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEDCTO_REFERENCE_TYPEDOCUabc");
            });

            modelBuilder.Entity<TypeDctoFolder>(entity =>
            {
                entity.HasKey(e => e.IdTypeDctoFolder)
                    .HasName("PK_TYPEDCTOFOLDER");

                entity.HasIndex(e => new { e.IdTypeFolder, e.IdTypeDocument })
                    .HasName("IX_TypeDctoFolder")
                    .IsUnique();

                entity.Property(e => e.IndividualSend).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithMany(p => p.TypeDctoFolder)
                    .HasForeignKey(d => d.IdTypeDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEDCTO_REFERENCE_TYPEDOCUABCD");

                entity.HasOne(d => d.IdTypeFolderNavigation)
                    .WithMany(p => p.TypeDctoFolder)
                    .HasForeignKey(d => d.IdTypeFolder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEDCTO_REFERENCE_TYPEFOLD");
            });

            modelBuilder.Entity<TypeDctoProfile>(entity =>
            {
                entity.HasKey(e => e.IdTypeDctoProfile)
                    .HasName("PK_TYPEDCTOPROFILE");

                entity.HasIndex(e => e.IdTypeDocument)
                    .HasName("IX_TypeDctoProfile")
                    .IsUnique();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsPrinted).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRePrinted).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsVisible).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdTypeDocumentNavigation)
                    .WithOne(p => p.TypeDctoProfile)
                    .HasForeignKey<TypeDctoProfile>(d => d.IdTypeDocument)
                    .HasConstraintName("FK_TYPEDCTO_REFERENCE_TYPEDOCU");
            });

            modelBuilder.Entity<TypeDocument>(entity =>
            {
                entity.HasKey(e => e.IdTypeDocument)
                    .HasName("PK_TYPEDOCUMENT");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_TypeDocument")
                    .IsUnique();

                entity.Property(e => e.BlodStorage)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CopyNumber).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdTypeForm).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdTypeImage).HasDefaultValueSql("((0))");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsCentrilizedOnline).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDigitizable).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsForm).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsScanLote).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVirtual).HasDefaultValueSql("((0))");

                entity.Property(e => e.Orientation)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Path)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Prefijo)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Profile)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Reprintable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeLive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<TypeFolder>(entity =>
            {
                entity.HasKey(e => e.IdTypeFolder)
                    .HasName("PK_TYPEFOLDER");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_TypeFolder")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<TypeFolderField>(entity =>
            {
                entity.HasKey(e => e.IdTypeFolderField)
                    .HasName("PK_TYPEFOLDERFIELD");

                entity.HasIndex(e => new { e.IdTypeFolder, e.CodeField })
                    .HasName("IX_TypeFolderField")
                    .IsUnique();

                entity.Property(e => e.CodeField)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConstant).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsObligatory).HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdFieldNavigation)
                    .WithMany(p => p.TypeFolderField)
                    .HasForeignKey(d => d.IdField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEFOLD_REFERENCE_FIELD");

                entity.HasOne(d => d.IdTypeFolderNavigation)
                    .WithMany(p => p.TypeFolderField)
                    .HasForeignKey(d => d.IdTypeFolder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TYPEFOLD_REFERENCE_TYPEFOLD");
            });

            modelBuilder.Entity<TypeImage>(entity =>
            {
                entity.HasKey(e => e.IdTypeImage)
                    .HasName("PK_TYPEIMAGE");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_TypeImage")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDuplex).HasDefaultValueSql("((0))");

                entity.Property(e => e.MultiPages).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberPages).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.VariablesPages).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<WaterMark>(entity =>
            {
                entity.HasKey(e => e.IdWaterMark)
                    .HasName("PK_WATERMARK");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_WaterMark")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });
        }
    }
}
