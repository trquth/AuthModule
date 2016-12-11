using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Auth.DTO.Models.Mapping
{
    public class admin_User_TokensMap : EntityTypeConfiguration<admin_User_Tokens>
    {
        public admin_User_TokensMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.SessionId)
                .IsRequired()
                .HasMaxLength(125);

            this.Property(t => t.Token)
                .IsRequired()
                .HasMaxLength(125);

            // Table & Column Mappings
            this.ToTable("admin_User_Tokens");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.SessionId).HasColumnName("SessionId");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.IsValid).HasColumnName("IsValid");
            this.Property(t => t.ExpireDate).HasColumnName("ExpireDate");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
