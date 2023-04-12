using ecommerce.domain.Constants;
using ecommerce.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce.infrastructure.Persistence.Configurations;
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .ToTable(TableNames.Address);

        builder
            .HasKey(ads => ads.Id);

        builder
            .Property(ads => ads.Country)
            .IsRequired(true);

        builder
            .Property(ads => ads.City)
            .IsRequired(true);

        builder
            .Property(ads => ads.Region)
            .IsRequired(true);

        builder
            .Property(ads => ads.Street)
            .IsRequired(true);

        builder
            .Property(ads => ads.PostalCode)
            .IsRequired(true);

        builder
            .HasData(GenerationAddress());
    }
    private List<Address> GenerationAddress()
    {
        return new List<Address>()
        {
            new Address
            {
                Country = "USA",
                City = "New York",
                Region = "Sant Erias",
                Street = "Elenberg",
                PostalCode = 4
            },
            new Address
            {
                Country = "Spain",
                City = "Madrid",
                Region = "Estro",
                Street = "sant - erias de mucho",
                PostalCode = 3
            }
        };
    }
}
