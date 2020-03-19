using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OpenDEVCore.Security.Entities;

namespace OpenDEVCore.Security.Repositories
{
    public partial class SecurityDBContext : CoreContext
    {
        public SecurityDBContext(DbContextOptions<SecurityDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Component> Component { get; set; }

        public virtual DbSet<InstitutionProfile> InstitutionProfile { get; set; }
        //public virtual DbSet<LogPassword> LogPassword { get; set; }
        public virtual DbSet<LogSecurity> LogSecurity { get; set; }
        public virtual DbSet<LogSupervision> LogSupervision { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<ProfileComponent> ProfileComponent { get; set; }
        public virtual DbSet<ProfileOption> ProfileOption { get; set; }
        public virtual DbSet<Supervision> Supervision { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserSupervision> UserSupervision { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<InstitutionProfile>(entity =>
            {
                entity.HasKey(e => e.IdInstitutionProfile)
                    .HasName("PK_INSTITUTIONPROFILE");

                entity.HasIndex(e => e.IdInstitution)
                    .HasName("IX_InstitutionProfile");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.InstitutionProfile)
                    .HasForeignKey(d => d.IdProfile)
                    .HasConstraintName("FK_INSTITUT_REFERENCE_PROFILE");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.IdComponent)
                    .HasName("PK_COMPONENT");

                entity.HasIndex(e => new { e.IdOption, e.ComponentName })
                    .HasName("IndUniq")
                    .IsUnique();

                entity.Property(e => e.ComponentName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdOptionNavigation)
                    .WithMany(p => p.Component)
                    .HasForeignKey(d => d.IdOption)
                    .HasConstraintName("FK_COMPONEN_REFERENCE_OPTION");
            });

            //modelBuilder.Entity<LogPassword>(entity =>
            //{
            //    entity.HasKey(e => e.IdUserPassword)
            //        .HasName("PK_USERPASSWORD");

            //    entity.HasIndex(e => e.IdUser)
            //        .HasName("IX_UserPassword");

            //    entity.Property(e => e.CreationDate).HasColumnType("datetime");

            //    entity.Property(e => e.CreationOfficeId)
            //        .HasColumnName("CreationOfficeID")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.CreationUserId)
            //        .HasColumnName("CreationUserID")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.Password)
            //        .IsRequired()
            //        .HasMaxLength(128)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateOfficeId)
            //        .HasColumnName("UpdateOfficeID")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.UpdateUserId)
            //        .HasColumnName("UpdateUserID")
            //        .HasDefaultValueSql("((0))");
            //});

            modelBuilder.Entity<LogSecurity>(entity =>
            {
                entity.HasKey(e => e.IdLogSecurity)
                    .HasName("PK_LOGSECURITY");

                entity.HasIndex(e => e.UserCode)
                    .HasName("IX_LogSecurity");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateRegistry).HasColumnType("datetime");

                entity.Property(e => e.Event)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Machine)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserCode)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogSupervision>(entity =>
            {
                entity.HasKey(e => e.IdLogSupervision)
                    .HasName("PK_LOGSUPERVISION");

                entity.HasIndex(e => e.IdUser)
                    .HasName("IX_LogSupervision");

                entity.Property(e => e.IdLogSupervision).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Observation)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Transaction)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK_MENU");

                entity.HasIndex(e => e.Channel)
                    .HasName("IX_Menu");

                entity.Property(e => e.Channel)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateSince).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Module)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.RouteLink)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasKey(e => e.IdOption)
                    .HasName("PK_OPTION");

                entity.HasIndex(e => e.IdMenu)
                    .HasName("IX_Option");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DashBoard)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Report)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.View)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.IdProfile)
                    .HasName("PK_PROFILE");

                entity.HasIndex(e => new { e.ProfileCode, e.IdInstitution })
                    .HasName("IX_Profile")
                    .IsUnique();

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateValidity).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<ProfileComponent>(entity =>
            {
                entity.HasKey(e => e.IdProfileComponent)
                    .HasName("PK_PROFILECOMPONENT");

                entity.HasOne(d => d.IdComponentNavigation)
                    .WithMany(p => p.ProfileComponent)
                    .HasForeignKey(d => d.IdComponent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFILEC_REFERENCE_COMPONEN");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.ProfileComponent)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFILEC_REFERENCE_PROFILE");
            });

            modelBuilder.Entity<ProfileOption>(entity =>
            {
                entity.HasKey(e => e.IdProfileOption)
                    .HasName("PK_PROFILEOPTION");

                entity.HasIndex(e => new { e.IdOption, e.IdProfile })
                    .HasName("IX_ProfileOption")
                    .IsUnique();

                entity.HasOne(d => d.IdOptionNavigation)
                    .WithMany(p => p.ProfileOption)
                    .HasForeignKey(d => d.IdOption)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFILEO_REFERENCE_OPTION");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.ProfileOption)
                    .HasForeignKey(d => d.IdProfile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFILEO_REFERENCE_PROFILE");
            });

            modelBuilder.Entity<Supervision>(entity =>
            {
                entity.HasKey(e => e.IdSupervision)
                    .HasName("PK_SUPERVISION");

                entity.HasIndex(e => e.SupervisionCode)
                    .HasName("IX_Supervision")
                    .IsUnique();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisionCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_USER");

                entity.HasIndex(e => e.UserCode)
                    .HasName("IX_User")
                    .IsUnique();

                entity.Property(e => e.CellPhone)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.CtlgState)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DateEndInactivity).HasColumnType("smalldatetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateLastAccess).HasColumnType("datetime");

                entity.Property(e => e.DateStartInactivity).HasColumnType("smalldatetime");

                entity.Property(e => e.DateUntil).HasColumnType("datetime");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.IdentificationType)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.InactivityType)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName1)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastName2)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Observation)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordDateMax).HasColumnType("smalldatetime");

                entity.Property(e => e.PcName)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserHomologation)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.IdUserProfile)
                    .HasName("PK_USERPROFILE");

                entity.HasIndex(e => new { e.IdUser, e.IdProfile })
                    .HasName("IX_UserProfile");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateUntil).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdProfileNavigation)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.IdProfile)
                    .HasConstraintName("FK_USERPROF_REFERENCE_PROFILE");
            });

            modelBuilder.Entity<UserSupervision>(entity =>
            {
                entity.HasKey(e => e.IdUserSupervision)
                    .HasName("PK_USERSUPERVISION");

                entity.HasIndex(e => new { e.IdSupervision, e.IdUser })
                    .HasName("IX_UserSupervision")
                    .IsUnique();

                entity.Property(e => e.IdUserSupervision).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CreationOfficeId).HasColumnName("CreationOfficeID");

                entity.Property(e => e.CreationUserId).HasColumnName("CreationUserID");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOfficeId).HasColumnName("UpdateOfficeID");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

                entity.HasOne(d => d.IdSupervisionNavigation)
                    .WithMany(p => p.UserSupervision)
                    .HasForeignKey(d => d.IdSupervision)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERSUPE_REFERENCE_SUPERVIS");
            });
        }
    }
}
