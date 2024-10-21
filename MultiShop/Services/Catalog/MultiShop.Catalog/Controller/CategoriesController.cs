using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService; 

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values =await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoryById(string id)
        {
           

            var values= await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);


        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {// Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //Category category =new Category();
            //category.CategoryName=createCategoryDto.CategoryName;

            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklenildi");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await  _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi");
        }
    }
}
