using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Auth.DTO.Models.Mapping
{
    public class admin_UsersMap : EntityTypeConfiguration<admin_Users>
    {
        public admin_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SSCId)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(125);

            this.Property(t => t.Email)
                .HasMaxLength(125);

            this.Property(t => t.Avatar)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("admin_Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserTypeId).HasColumnName("UserTypeId");
            this.Property(t => t.OrganisationId).HasColumnName("OrganisationId");
            this.Property(t => t.SSCId).HasColumnName("SSCId");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.IsBanned).HasColumnName("IsBanned");
            this.Property(t => t.EndBannedDate).HasColumnName("EndBannedDate");
            this.Property(t => t.IsOnline).HasColumnName("IsOnline");
            this.Property(t => t.Avatar).HasColumnName("Avatar");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.BillerId).HasColumnName("BillerId");
        }
    }
}
