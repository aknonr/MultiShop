using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductList()
        {
            var values = await _ProductService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            // Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //Product Product =new Product();
            //Product.ProductName=createProductDto.ProductName;

            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi");


        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi");
        }
    }
}
