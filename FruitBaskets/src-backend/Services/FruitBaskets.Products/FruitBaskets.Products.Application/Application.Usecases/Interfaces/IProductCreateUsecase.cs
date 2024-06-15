namespace FruitBaskets.Products.Application
{
    public interface IProductCreateUsecase
    {
        Task CreateProduct(ProductCreateDto productDto);
    }
}
