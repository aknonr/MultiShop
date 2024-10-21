using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";


            //Burada var olan apiden veri çekmemizi sağlayan consume tarafı. GElen json verisini metine çevirecez. 
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Desarialize yapmamızmın sebebi listeyi listelemek için yapıyoruz. 
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("CreateProduct")]
        [HttpGet]

        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories"); // Api ucuna get isteği göndnerdik
            var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Burada apiden döenen json yanıtının gövdesini alıp bir stirng olarak döner bize.
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);  //Bu adımda, JSON formatındaki veri bir C# listesine deserialize ediliyor. Yani, jsonData olarak gelen string, List<ResultCategoryDto> türüne dönüştürülüyor. 
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues;  //Bu satırda, kategorilerden oluşturduğumuz SelectListItem listesini ViewBag aracılığıyla view'e (görünüme) aktarıyoruz

            return View();
        }


        [HttpPost]
        [Route("CreateProduct")]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            //ekleme yaparken Serialize yaparız . 
            var jsondData = JsonConvert.SerializeObject(createProductDto); //createCategorydto aldığımız veriyi json formata dönüştürdük
            StringContent stringContent = new StringContent(jsondData, Encoding.UTF8, "application/json"); //oluşturduğumuz değeri bir content olarak atadık ve dil desteğini yaptık 2. parametrede.
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProducty(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Products?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { arae = "Admin" });
            }
            return View();
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]

        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme Sayfası";
            ViewBag.v0 = "Ürün İşlemleri";


            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:7070/api/Categories"); // Api ucuna get isteği göndnerdik
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync(); //Burada apiden döenen json yanıtının gövdesini alıp bir stirng olarak döner bize.
            var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);  //Bu adımda, JSON formatındaki veri bir C# listesine deserialize ediliyor. Yani, jsonData olarak gelen string, List<ResultCategoryDto> türüne dönüştürülüyor. 
            List<SelectListItem> categoryValues1 = (from x in values1
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();

            ViewBag.CategoryValues = categoryValues1;  //Bu satırda, kategorilerden oluşturduğumuz SelectListItem listesini ViewBag aracılığıyla view'e (görünüme) aktarıyoruz

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }

            return View();
        }


        [Route("UpdateProduct/{id}")]
        [HttpPost]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Products/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { arae = "Admin" });
            }

            return View();
        }


    }
}
