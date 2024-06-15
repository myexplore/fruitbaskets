namespace FruitBaskets.Products.Application
{
    public class ProductGetDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
