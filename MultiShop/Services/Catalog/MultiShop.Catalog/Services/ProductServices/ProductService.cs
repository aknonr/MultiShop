using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService

    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            
        }
        
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
         await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var values =await _productCollection.Find(x=> true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            // Ürün ve kategori verilerini paralel olarak çekiyoruz
            var productTask =  _productCollection.Find<Product>(x => true).ToListAsync();
            var categoryTask =  _categoryCollection.Find<Category>(x => true).ToListAsync();
            
            await Task.WhenAll(productTask, categoryTask);
            
           
            var products = await productTask;
            var categories = await categoryTask;

            // Kategorileri Dictionary ile CategoryId'ye göre eşliyoruz
            var categoryDict = categories.ToDictionary(c => c.CategoryId, c => c.CategoryName);

            // Ürünleri DTO'ya map ediyoruz
            var result = _mapper.Map<List<ResultProductsWithCategoryDto>>(products);

            foreach (var item in result)
            {
                // Daha hızlı erişim için Dictionary kullanarak kategori adını eşliyoruz
                item.CategoryName = categoryDict.ContainsKey(item.CategoryId)
                                    ? categoryDict[item.CategoryId]
                                    : "Category Not Found";
            }

            // Tekrar map etmeye gerek yok, result zaten doğru yapıda olacaktır 
            return result;
        }


        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
          var values = await _productCollection.Find<Product>(x=>x.ProductId==id).FirstOrDefaultAsync();

            return _mapper.Map<GetByIdProductDto>(values);
        }

      
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
           
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }

       
    }
}
