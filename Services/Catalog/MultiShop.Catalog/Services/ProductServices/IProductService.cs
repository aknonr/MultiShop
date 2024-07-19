using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    { 
        //Product ile ilgili crud metotlarını tutacağımız sınıftır

        Task<List<ResultProductDto>> GetAllProductAsync(); //Bütün veriliermizi getirecek metot

        Task CreateProductAsync(CreateProductDto createProductDto); //Ekleme işlemi 

        Task UpdateProductAsync(UpdateProductDto updateProductDto); //Güncelleme islemi yapacak metot

        Task DeleteProductAsync(string id);                           //Silme islemi yapacak metot

        Task<GetByIdProductDto> GetByIdProductAsync(string id);        //Id 'e göre getirme islemi
    }
}
