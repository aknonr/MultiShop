using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {

        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings) //_databaseSettings isminde bir field örneklemesi yapacak. 
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);   //Client diye bir degisken olusturduk . Connectingstringse erisim saglamamız gerekiyor çinde sağlanan bağlantı dizesini kullanarak MongoDB sunucusuna veya kümesine bir bağlantı kurar. Bağlantı dizesi genellikle sunucu adresi, port numarası, veritabanı adı ve bağlantı için gereken kimlik doğrulama bilgilerini içerir.  Yani burda bağlantıyı oluşturuyoruz. 

            var database = client.GetDatabase(_databaseSettings.DatabaseName);  //Burada database erisimi saglandı.

            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);  
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);

            await _featureSliderCollection.InsertOneAsync(value);  //MongoDb 'de ekleme işlemi InsertOneAsync ile yapılıyor . 
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, values);
        }
    }
}
