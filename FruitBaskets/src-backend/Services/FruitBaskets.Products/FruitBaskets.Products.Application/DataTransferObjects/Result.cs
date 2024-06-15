namespace FruitBaskets.Products.Application
{
    public class Result<T>
    {
        public T Payload { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}
