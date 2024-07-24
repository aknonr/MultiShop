using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        //Category ile ilgili crud metotlarını tutacağımız sınıftır

        Task<List<ResultCategoryDto>> GetAllCategoryAsync(); //Bütün veriliermizi getirecek metot

        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto); //Ekleme işlemi 

        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto); //Güncelleme islemi yapacak metot

        Task DeleteCategoryAsync(string id);                           //Silme islemi yapacak metot

        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);        //Id 'e göre getirme islemi

    }
}
