
using FruitBaskets.Domain;

namespace FruitBaskets.Products.Application
{
    public class ProductCreateUsecase : IProductCreateUsecase
    {
        private readonly IDataService dataService;

        public ProductCreateUsecase(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task CreateProduct(ProductCreateDto productDto)
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Category = productDto.Category,
                Price = productDto.Price,
                Description = productDto.Description
            };
            await dataService.CreateAsync(product);
            
      

        }
    }
}
