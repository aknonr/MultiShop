using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        //FeatureSlider ile ilgili crud metotlarını tutacağımız sınıftır

        Task<List<ResultFeatureSliderDto>> GetAllFeatureAsync(); //Bütün veriliermizi getirecek metot

        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto); //Ekleme işlemi 

        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto); //Güncelleme islemi yapacak metot

        Task DeleteFeatureSliderAsync(string id);                           //Silme islemi yapacak metot

        Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id);        //Id 'e göre getirme islemi

        Task FeatureSliderChangeStatusToTrue(string id);

        Task FeatureSliderChangeStatusToFalse(string id);

    }
}
