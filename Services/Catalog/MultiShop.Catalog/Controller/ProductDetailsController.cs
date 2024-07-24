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
        private readonly IProductDetailService _productDetailsService;

        public ProductDetailsController(IProductDetailService ProductDetailsService)
        {
            _productDetailsService = ProductDetailsService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _productDetailsService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductDetailsById(string id)
        {
           
            var values= await _productDetailsService.GetByIdProductDetailAsync(id);
            return Ok(values);


        }

        [HttpPost]

        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            // Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //ProductDetails ProductDetails =new ProductDetails();
            //ProductDetails.ProductDetailsName=createProductDetailsDto.ProductDetailsName;

            await _productDetailsService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarıl şekilde eklenildi");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _productDetailsService.DeleteProductDetailAsync(id);
            return Ok("\"Ürün detayı başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _productDetailsService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
