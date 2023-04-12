using ecommerce.domain.Constants;
using ecommerce.domain.Entities;
using ecommerce.domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
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
            .HasOne(usr => usr.Address)
            .WithMany(ads => ads.Users)
            .HasForeignKey(usr => usr.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasData(GenerationUsers());
    }
    private List<Users> GenerationUsers()
    {
        return new List<Users>
        {
            new Users
            {
                Id = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e079"),
                Fullname = "Javokhir Djumanov",
                Email = "javokhirdjumanov@gmail.com",
                Username = "javokhirdjumanov",
                Phonenumber = "94 057 77 21",
                Password = "7777",
                Salt = Guid.NewGuid().ToString(),
                Role = UserRoles.Admin,
                AddressId = Guid.Parse("bc56836e-0345-4f01-a883-47f39e32e077"),
            }
        };
    }
}
