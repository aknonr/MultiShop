using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]

        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductImageById(string id)
        {
            
           var values=_ProductImageService.GetByIdProductImageAsync(id);
            return Ok(values);


        }

        [HttpPost]

        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            // Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //ProductImage ProductImage =new ProductImage();
            //ProductImage.ProductImageName=createProductImageDto.ProductImageName;

            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görselleri başarıyla Eklenildi");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görselleri başarıyla güncellendi");
        }
    }
}
