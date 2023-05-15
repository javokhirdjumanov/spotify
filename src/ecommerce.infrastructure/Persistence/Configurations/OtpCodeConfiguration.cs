using ecommerce.domain.Constants;
using ecommerce.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.infrastructure.Persistence.Configurations;
public class OtpCodeConfiguration 
    : IEntityTypeConfiguration<OtpCode>
{
    public void Configure(EntityTypeBuilder<OtpCode> builder)
    {
        builder.ToTable(TableNames.OtpCodes);

        builder.HasKey(o => o.Id);

        builder
            .Property(o => o.Code)
            .IsRequired(true)
            .HasMaxLength(6);

        builder
            .Property(o => o.CreateAt)
            .IsRequired(true);

        builder
            .Property(o => o.Status)
            .IsRequired(true);

        builder
            .HasOne(o => o.User)
            .WithMany(u => u.OtpCodes)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
