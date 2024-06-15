using FruitBaskets.Products.Application;
using Microsoft.AspNetCore.Mvc;

namespace FruitBaskets.Products.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductGetUsecase productGetUsecase;
        private readonly IProductCreateUsecase productCreateUsecase;

        public ProductController(IServiceProvider provider)
        {
            productGetUsecase = provider.GetRequiredService<IProductGetUsecase>();
            productCreateUsecase=provider.GetRequiredService<IProductCreateUsecase>();
        }
        [HttpGet]       
        public async Task<Result<IEnumerable<ProductGetDto>>> GetProducts()
        {
            var products = await productGetUsecase.GetProductsAsync();
            return new Result<IEnumerable<ProductGetDto>>() { Payload = products };

        }
        [HttpPost]
        public async Task<Result<string>> CreateProduct([FromBody] ProductCreateDto productDto)
        {
             await productCreateUsecase.CreateProduct(productDto);
            return new Result<string>() { };
           

        }
    }
}
