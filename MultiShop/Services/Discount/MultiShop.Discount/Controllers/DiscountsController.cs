using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDisCountService _discountService;

        /// <summary>
        /// DiscountsController constructor'ı, IDisCountService bağımlılığını alır.
        /// </summary>

        public DiscountsController(IDisCountService discountService)
        {
            _discountService = discountService;
        }


        /// <summary>
        /// Tüm discount kuponlarını getirir.
        /// </summary>
        /// <returns>Tüm discount kuponlarının listesi</returns>


        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }


        // <summary>
        /// Belirtilen ID'ye sahip discount kuponunu getirir.
        /// </summary>
        /// <param name="id">Kupon ID'si</param>
        /// <returns>Belirtilen ID'ye sahip discount kuponu</returns>



        // HTTPGET ATTRİBUTU bize Id'ye göre dicount kuponlarını getirir . 

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);

            return Ok(values); //Burada alınan deger (kupon bilgisi) Http 200 ok yanıtı ile birlikte bize değer döndürür


        }



        //Yeni Bir Discount Kuponu olusturdugumuz yerdir .

        [HttpPost]

        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon başarılı sekilde eklenildi");
        }


        // Belirtilen ID'ye sahip discount kuponunu siler.

        [HttpDelete]

        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);

            return Ok("Kupon başarıyla silindi");
        }


        //Mevcut bir discount kuponunu güncelle

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);

            return Ok("Kupon başarılı sekilde güncellendi");

        }
    }
}
