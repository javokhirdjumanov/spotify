namespace ecommerce.domain.Entities
{
    public class OrderDetalies
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Orders Orders { get; set; }

        public Guid ProductId { get; set; }
        public Products Products { get; set; }
    }
}
