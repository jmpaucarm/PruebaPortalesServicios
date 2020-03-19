using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenDEVCore.DocBlobStorage.Entities;

namespace OpenDEVCore.DocBlobStorage
{
    public partial class DocBlodStorageContext : CoreContext
    {


        public DocBlodStorageContext(DbContextOptions<DocBlodStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Box> Box { get; set; }
        public virtual DbSet<BoxField> BoxField { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentField> DocumentField { get; set; }
        public virtual DbSet<DocumentLog> DocumentLog { get; set; }
        public virtual DbSet<Folder> Folder { get; set; }
        public virtual DbSet<FolderField> FolderField { get; set; }
        public virtual DbSet<Location> Location { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Box>(entity =>
            {
                entity.HasKey(e => e.IdBox)
                    .HasName("PK_BOX");

                entity.HasIndex(e => new { e.CodeTypeBox, e.Institution })
                    .HasName("IX_Box");

                entity.Property(e => e.CodeTypeBox)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateEnd).HasColumnType("smalldatetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NumberItems).HasDefaultValueSql("((0))");

  
                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdLocationNavigation)
                    .WithMany(p => p.Box)
                    .HasForeignKey(d => d.IdLocation)
                    .HasConstraintName("FK_BOX_REFERENCE_LOCATION");
            });

            modelBuilder.Entity<BoxField>(entity =>
            {
                entity.HasKey(e => e.IdBoxField)
                    .HasName("PK_BOXFIELD");

                entity.HasIndex(e => new { e.Value, e.CodeField, e.Institution })
                    .HasName("IX_BoxField");

                entity.Property(e => e.CodeField)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBoxNavigation)
                    .WithMany(p => p.BoxField)
                    .HasForeignKey(d => d.IdBox)
                    .HasConstraintName("FK_BOXFIELD_REFERENCE_BOX");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.IdDocument)
                    .HasName("PK_DOCUMENT");

                entity.HasIndex(e => new { e.CodeTypeDocument, e.Institution })
                    .HasName("IX_Document");

                entity.Property(e => e.CodeDocument)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CodeTypeDocument)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateEnd).HasColumnType("smalldatetime");

                entity.Property(e => e.IdBox).HasDefaultValueSql("((0))");

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsCopy)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");


                entity.Property(e => e.IsVirtual).HasDefaultValueSql("((0))");

                entity.Property(e => e.PathDocument)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PathDocumentFinal)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.PathDocumentOrigen)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdFolderNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.IdFolder)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_FOLDER");
            });

            modelBuilder.Entity<DocumentField>(entity =>
            {
                entity.HasKey(e => e.IdDocumentField)
                    .HasName("PK_DOCUMENTFIELD");

                entity.HasIndex(e => new { e.Value, e.CodeField, e.Institution })
                    .HasName("IXDocumentField");

                entity.Property(e => e.CodeField)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.DocumentField)
                    .HasForeignKey(d => d.IdDocument)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_DOCUMENTFIELD");
            });

            modelBuilder.Entity<DocumentLog>(entity =>
            {
                entity.HasKey(e => e.IdDocumentLog)
                    .HasName("PK_DOCUMENTLOG");

                entity.Property(e => e.PathDocument)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.DocumentLog)
                    .HasForeignKey(d => d.IdDocument)
                    .HasConstraintName("FK_DOCUMENT_REFERENCE_DOCUMENT");
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasKey(e => e.IdFolder)
                    .HasName("PK_FOLDER");

                entity.HasIndex(e => new { e.CodeTypeFolder, e.Institution })
                    .HasName("IX_Folder");

                entity.Property(e => e.CodeTypeFolder)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateEnd).HasColumnType("smalldatetime");

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

                entity.Property(e => e.Path)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdBoxNavigation)
                    .WithMany(p => p.Folder)
                    .HasForeignKey(d => d.IdBox)
                    .HasConstraintName("FK_FOLDER_REFERENCE_BOX");
            });

            modelBuilder.Entity<FolderField>(entity =>
            {
                entity.HasKey(e => e.IdFolderField)
                    .HasName("PK_FOLDERFIELD");

                entity.HasIndex(e => new { e.Value, e.CodeField, e.Institution })
                    .HasName("IX_FolderField");

                entity.Property(e => e.CodeField)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Value)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFolderNavigation)
                    .WithMany(p => p.FolderField)
                    .HasForeignKey(d => d.IdFolder)
                    .HasConstraintName("FK_FOLDERFI_REFERENCE_FOLDER");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.IdLocation)
                    .HasName("PK_LOCATION");

                entity.HasIndex(e => new { e.Code, e.Institution })
                    .HasName("IX_Location");

                entity.Property(e => e.Code)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Hijo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Institution)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsLastNode).HasDefaultValueSql("((0))");

                entity.Property(e => e.Padre).HasDefaultValueSql("((0))");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });
        }
    }
}
