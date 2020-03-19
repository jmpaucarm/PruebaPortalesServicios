using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OpenDEVCore.Configuration.Entities;

namespace OpenDEVCore.Configuration.Repositories
{
    public partial class ConfigurationSCContext : CoreContext
    {
        //public ConfigurationSCContext()
        //{
        //}

        //public ConfigurationSCContext(DbContextOptions<ConfigurationSCContext> options)
        //    : base(options)
        //{
        //}
        public ConfigurationSCContext(DbContextOptions<ConfigurationSCContext> options) : base(options)
        {

        }
        public virtual DbSet<Catalogue> Catalogue { get; set; }
        public virtual DbSet<CatalogueDetail> CatalogueDetail { get; set; }
        public virtual DbSet<CatalogueDetailIns> CatalogueDetailIns { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<EsbendPoint> EsbendPoint { get; set; }
        public virtual DbSet<EsbendPointException> EsbendPointException { get; set; }
        public virtual DbSet<Esbexception> Esbexception { get; set; }
        public virtual DbSet<GeographicLocation1> GeographicLocation1 { get; set; }
        public virtual DbSet<GeographicLocation2> GeographicLocation2 { get; set; }
        public virtual DbSet<GeographicLocation3> GeographicLocation3 { get; set; }
        public virtual DbSet<GeographicLocation4> GeographicLocation4 { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<InstitutionSystem> InstitutionSystem { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<ParameterInstitution> ParameterInstitution { get; set; }
        public virtual DbSet<RegionInstitution> RegionInstitution { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Catalogue>(entity =>
            {
                entity.HasKey(e => e.IdCatalogue)
                    .HasName("PK_CATALOGUE");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Catalogue")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<CatalogueDetail>(entity =>
            {
                entity.HasKey(e => e.IdCatalogueDetail)
                    .HasName("PK_CATALOGUEDETAIL");

                entity.HasIndex(e => new { e.Code, e.IdCatalogue })
                    .HasName("IX_CatalogueDetail")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Order).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdCatalogueNavigation)
                    .WithMany(p => p.CatalogueDetail)
                    .HasForeignKey(d => d.IdCatalogue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATALOGU_REFERENCE_CATALOGU1");
            });

            modelBuilder.Entity<CatalogueDetailIns>(entity =>
            {
                entity.HasKey(e => e.IdCatalogueDetailsIns)
                    .HasName("PK_CATALOGUEDETAILINS");

                entity.Property(e => e.IdCatalogueDetailsIns)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCatalogueNavigation)
                    .WithMany(p => p.CatalogueDetailIns)
                    .HasForeignKey(d => d.IdCatalogue)
                    .HasConstraintName("FK_CATALOGU_REFERENCE_CATALOGU");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.CatalogueDetailIns)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("FK_CATALOGU_REFERENCE_INSTITUT");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK_COUNTRY");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Country")
                    .IsUnique();

                entity.Property(e => e.AreaCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ShortCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EsbendPoint>(entity =>
            {
                entity.HasKey(e => e.IdEsbendPoint)
                    .HasName("PK_ESBENDPOINT");

                entity.ToTable("ESBEndPoint");

                entity.Property(e => e.IdEsbendPoint).HasColumnName("IdESBEndPoint");

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EsbendPointException>(entity =>
            {
                entity.HasKey(e => e.IdEsbendPointException)
                    .HasName("PK_ESBENDPOINTEXCEPTION");

                entity.ToTable("ESBEndPointException");

                entity.HasIndex(e => new { e.IdEsbendPoint, e.EndPointErrorCode })
                    .HasName("IX_ESBEndpointException")
                    .IsUnique();

                entity.Property(e => e.IdEsbendPointException).HasColumnName("IdESBEndPointException");

                entity.Property(e => e.EndPointErrorCode)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.EndPointMessage)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IdEsbendPoint).HasColumnName("IdESBEndPoint");

                entity.Property(e => e.IdEsbexception).HasColumnName("IdESBException");

                entity.HasOne(d => d.IdEsbendPointNavigation)
                    .WithMany(p => p.EsbendPointException)
                    .HasForeignKey(d => d.IdEsbendPoint)
                    .HasConstraintName("FK_ESBENDPO_REFERENCE_ESBENDPO");

                entity.HasOne(d => d.IdEsbexceptionNavigation)
                    .WithMany(p => p.EsbendPointException)
                    .HasForeignKey(d => d.IdEsbexception)
                    .HasConstraintName("FK_ESBENDPO_REFERENCE_ESBEXCEP");
            });

            modelBuilder.Entity<Esbexception>(entity =>
            {
                entity.HasKey(e => e.IdEsbexception)
                    .HasName("PK_ESBEXCEPTION");

                entity.ToTable("ESBException");

                entity.Property(e => e.IdEsbexception).HasColumnName("IdESBException");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeographicLocation1>(entity =>
            {
                entity.HasKey(e => e.IdGeographicLocation1)
                    .HasName("PK_GEOGRAPHICLOCATION1");

                entity.HasIndex(e => e.GeographicLocation1Code)
                    .HasName("IX_GeographicLocation1")
                    .IsUnique();

                entity.Property(e => e.GeographicLocation1Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.GeographicLocation1)
                    .HasForeignKey(d => d.IdCountry)
                    .HasConstraintName("FK_GEOGRAPH_REFERENCE_COUNTRY");
            });

            modelBuilder.Entity<GeographicLocation2>(entity =>
            {
                entity.HasKey(e => e.IdGeographicLocation2)
                    .HasName("PK_GEOGRAPHICLOCATION2");

                entity.HasIndex(e => e.GeographicLocation2Code)
                    .HasName("IX_GeographicLocation2")
                    .IsUnique();

                entity.Property(e => e.GeographicLocation2Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeographicLocation1Navigation)
                    .WithMany(p => p.GeographicLocation2)
                    .HasForeignKey(d => d.IdGeographicLocation1)
                    .HasConstraintName("FK_GEOGRAPH_REFERENCE_GEOGRAPH2");
            });

            modelBuilder.Entity<GeographicLocation3>(entity =>
            {
                entity.HasKey(e => e.IdGeographicLocation3)
                    .HasName("PK_GEOGRAPHICLOCATION3");

                entity.HasIndex(e => e.GeographicLocation3Code)
                    .HasName("IX_GeographicLocation3")
                    .IsUnique();

                entity.Property(e => e.GeographicLocation3Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeographicLocation2Navigation)
                    .WithMany(p => p.GeographicLocation3)
                    .HasForeignKey(d => d.IdGeographicLocation2)
                    .HasConstraintName("FK_GEOGRAPH_REFERENCE_GEOGRAPH3");
            });

            modelBuilder.Entity<GeographicLocation4>(entity =>
            {
                entity.HasKey(e => e.IdGeographicLocation4)
                    .HasName("PK_GEOGRAPHICLOCATION4");

                entity.HasIndex(e => e.GeographicLocation4Code)
                    .HasName("IX_GeographicLocation4");

                entity.Property(e => e.GeographicLocation4Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeographicLocation3Navigation)
                    .WithMany(p => p.GeographicLocation4)
                    .HasForeignKey(d => d.IdGeographicLocation3)
                    .HasConstraintName("FK_GEOGRAPH_REFERENCE_GEOGRAPH4");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.IdHoliday)
                    .HasName("PK_HOLIDAY");

                entity.HasIndex(e => e.IdGeographicLocation2)
                    .HasName("IX_Holiday1");

                entity.HasIndex(e => new { e.DateHoliday, e.IdGeographicLocation2 })
                    .HasName("IX_Holiday")
                    .IsUnique();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateHoliday).HasColumnType("smalldatetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.HasKey(e => e.IdInstitution)
                    .HasName("PK_INSTITUTION");

                entity.HasIndex(e => e.Ruc)
                    .HasName("IX_Institution")
                    .IsUnique();

                entity.HasIndex(e => e.Code)
                    .HasName("IX_InstitutionCode")
                    .IsUnique();


                entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Design)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                
                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsOwner).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeDni)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeEmail)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeName)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativePhone)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeTypeDni)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<InstitutionSystem>(entity =>
            {
                entity.HasKey(e => e.IdInstitutionSystem)
                    .HasName("PK_INSTITUTIONSYSTEM");

                entity.HasIndex(e => e.IdInstitution)
                    .HasName("IX_InstitutionSystem");

                entity.Property(e => e.System)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.InstitutionSystem)
                    .HasForeignKey(d => d.IdInstitution)
                    .HasConstraintName("FK_INSTITUT_REFERENCE_INSTITUT");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(e => e.IdOffice)
                    .HasName("PK_OFFICE");

                entity.HasIndex(e => new { e.Name, e.IdInstitution })
                    .HasName("IX_Office")
                    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CoordinateX)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CoordinateY)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.IdOfficeCtb).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdOfficeDepend)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OFFICE_REFERENCE_INSTITUT");
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.HasKey(e => e.IdParameter)
                    .HasName("PK_PARAMETER");

                entity.HasIndex(e => e.Code)
                    .HasName("IX_Parameter")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeID).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserID).HasColumnName("CreationUserID");

                entity.Property(e => e.DateValue).HasColumnType("datetime");

                entity.Property(e => e.DecimalValue).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEncripted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsInstitution).HasDefaultValueSql("((0))");

                entity.Property(e => e.System)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.TextValue)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeID).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserID).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<ParameterInstitution>(entity =>
            {
                entity.HasKey(e => e.IdParameterInstitution)
                    .HasName("PK_PARAMETERINSTITUTION");

                entity.HasIndex(e => new { e.IdParameter, e.IdInstitution })
                    .HasName("IX_ParameterInstitution")
                    .IsUnique();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateValue).HasColumnType("datetime");

                entity.Property(e => e.DecimalValue).HasColumnType("decimal(19, 2)");

                entity.Property(e => e.TextValue)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdParameterNavigation)
                    .WithMany(p => p.ParameterInstitution)
                    .HasForeignKey(d => d.IdParameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_REFERENCE_PARAMETE");
            });

            modelBuilder.Entity<RegionInstitution>(entity =>
            {
                entity.HasKey(e => e.IdRegionInstitution)
                    .HasName("PK_REGIONINSTITUTION");

                entity.Property(e => e.Code)
                    .HasColumnName("Code_")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.HasKey(e => e.IdZone)
                    .HasName("PK_ZONE");

                entity.HasIndex(e => e.GeographicLocationCode)
                    .HasName("IX_Countryn");

                entity.Property(e => e.Data)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.GeographicLocationCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });
        }
    }
}
