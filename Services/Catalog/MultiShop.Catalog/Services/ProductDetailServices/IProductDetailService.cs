using MultiShop.Catalog.Dtos.ProductDetailDto;

namespace MultiShop.Catalog.Services.ProductDetailDetailServices
{
    public interface IProductDetailService
    {
        //ProductDetail ile ilgili crud metotlarını tutacağımız sınıftır

        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync(); //Bütün veriliermizi getirecek metot

        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto); //Ekleme işlemi 

        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto); //Güncelleme islemi yapacak metot

        Task DeleteProductDetailAsync(string id);                           //Silme islemi yapacak metot

        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);        //Id 'e göre getirme islemi


    }
}
