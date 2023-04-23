using System.ComponentModel.DataAnnotations;

namespace ecommerce.domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        public short PostalCode { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
