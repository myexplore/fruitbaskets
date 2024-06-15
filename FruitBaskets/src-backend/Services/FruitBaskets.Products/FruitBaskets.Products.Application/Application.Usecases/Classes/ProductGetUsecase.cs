using FruitBaskets.Domain;

namespace FruitBaskets.Products.Application
{
    public class ProductGetUsecase : IProductGetUsecase
    {
        private readonly IDataService dataService;

        public ProductGetUsecase(IDataService _dataService)
        {
            this.dataService = _dataService;
        }
        public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
        {
            var products = await dataService.GetAllAsync<Product>();
            List<ProductGetDto> productDtos = new List<ProductGetDto>();
            foreach (var product in products)
            {
                productDtos.Add(new ProductGetDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    Price = product.Price
                });
            }
            return productDtos;
        }
    }
}
