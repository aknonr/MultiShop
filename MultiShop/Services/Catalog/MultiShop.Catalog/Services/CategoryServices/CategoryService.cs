using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings) //_databaseSettings isminde bir field örneklemesi yapacak. 
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);   //Client diye bir degisken olusturduk . Connectingstringse erisim saglamamız gerekiyor çinde sağlanan bağlantı dizesini kullanarak MongoDB sunucusuna veya kümesine bir bağlantı kurar. Bağlantı dizesi genellikle sunucu adresi, port numarası, veritabanı adı ve bağlantı için gereken kimlik doğrulama bilgilerini içerir.  Yani burda bağlantıyı oluşturuyoruz. 

            var database=client.GetDatabase(_databaseSettings.DatabaseName);  //Burada database erisimi saglandı.

            _categoryCollection=database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);  //_categoryCollection'a atamayı gerceklestirmis olduk.

            _mapper = mapper;
        }

      

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value=_mapper.Map<Category>(createCategoryDto);

            await _categoryCollection.InsertOneAsync(value);  //MongoDb 'de ekleme işlemi InsertOneAsync ile yapılıyor . 
         

        }

        public async Task DeleteCategoryAsync(string id)
        {
           await _categoryCollection.DeleteOneAsync(x=>x.CategoryId==id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map< List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values =await _categoryCollection.Find<Category>(x=>x.CategoryId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryId==updateCategoryDto.CategoryId,values);
        }
    }
}
