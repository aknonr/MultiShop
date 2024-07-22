using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Services.ProductDetailDetailServices;


namespace MultiShop.Catalog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailsService;

        public ProductDetailsController(IProductDetailService ProductDetailsService)
        {
            _ProductDetailsService = ProductDetailsService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            // Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //ProductDetails ProductDetails =new ProductDetails();
            //ProductDetails.ProductDetailsName=createProductDetailsDto.ProductDetailsName;

            await _ProductDetailsService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Ürün detayı başarıyla eklendi");


        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _ProductDetailsService.DeleteProductDetailAsync(id);
            return Ok("\"Ürün detayı başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _ProductDetailsService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
