using System.ComponentModel.DataAnnotations;

namespace ecommerce.domain.Entities
{
    public sealed class Products
    {
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public ICollection<OrderDetalies> OrderDetalies { get; set; }

        public Guid CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
