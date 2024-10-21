using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }

        [HttpGet]

        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFeatureSliderById(string id)
        {


            var values = await _FeatureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);


        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {// Mapleme yapmasaydık bu nesne örneği üzerinde her birine proeperty atama yapmamiz  gerekiyordu Asagıdaki gibi atama yapacaktık
            //FeatureSlider FeatureSlider =new FeatureSlider();
            //FeatureSlider.FeatureSliderName=createFeatureSliderDto.FeatureSliderName;

            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne Çıkan Görsel Başarıyla Eklenildi");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteCtegory(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne Çıkan Görsel başarıyla silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne Çıkan Görsel başarıyla güncellendi");
        }
    }
}
