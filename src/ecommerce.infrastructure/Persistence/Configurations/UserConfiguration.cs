using ecommerce.domain.Constants;
using ecommerce.domain.Entities;
using ecommerce.domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable(TableNames.Users);

        builder
            .HasKey(usr => usr.Id);

        builder
            .Property(usr => usr.Fullname)
            .IsRequired(true);

        builder
            .Property(usr => usr.Email)
            .IsRequired(true);

        builder
            .HasIndex(u => u.Email)
            .IsUnique(true);

        builder
            .Property(usr => usr.Username)
            .IsRequired(true);

        builder
            .Property(usr => usr.Phonenumber)
            .IsRequired(true);

        builder
            .Property(usr => usr.Password)
            .IsRequired(true);

        builder
            .Property(usr => usr.Salt)
            .IsRequired(true);

        builder
            .Property(usr => usr.Role)
            .IsRequired(true);

        builder
            .Property(usr => usr.LastLogin)
            .IsRequired(false);

        builder
            .HasOne(usr => usr.Address)
            .WithMany(ads => ads.Users)
            .HasForeignKey(usr => usr.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
