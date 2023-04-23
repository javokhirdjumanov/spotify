using ecommerce.domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(30)]
        public string Fullname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Username { get; set; }

        [MaxLength(30)]
        public string Phonenumber { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Salt { get; set; }

        public UserRoles Role { get; set; }

        public Guid AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
