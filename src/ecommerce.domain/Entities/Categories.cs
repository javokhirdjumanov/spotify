namespace ecommerce.domain.Entities
{
    public sealed class Categories
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
