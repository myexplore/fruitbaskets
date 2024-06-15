namespace FruitBaskets.Products.Application
{
    public interface IProductGetUsecase:IScoped
    {
        Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    }
}
