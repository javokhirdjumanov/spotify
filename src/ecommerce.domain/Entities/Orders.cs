namespace ecommerce.domain.Entities
{
    public class Orders
    {
        public Guid Id { get; set; }

        public Guid CustomerId{ get; set; }
        public User User { get; set; }

        public ICollection<OrderDetalies> OrderDetalies { get; set; }
    }
}
