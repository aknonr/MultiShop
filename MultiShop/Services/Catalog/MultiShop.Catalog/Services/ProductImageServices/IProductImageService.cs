using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        //ProductImage ile ilgili crud metotlarını tutacağımız sınıftır

        Task<List<ResultProductImageDto>> GetAllProductImageAsync(); //Bütün veriliermizi getirecek metot

        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto); //Ekleme işlemi 

        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto); //Güncelleme islemi yapacak metot

        Task DeleteProductImageAsync(string id);                           //Silme islemi yapacak metot

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);        //Id 'e göre getirme islemi
    }
}
