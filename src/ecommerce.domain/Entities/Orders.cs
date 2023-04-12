namespace ecommerce.domain.Entities
{
    public class Orders
    {
        public Guid Id { get; set; }

        public Guid CustomerId{ get; set; }
        public Customers Customer { get; set; }

        public ICollection<OrderDetalies> OrderDetalies { get; set; }
    }
}
