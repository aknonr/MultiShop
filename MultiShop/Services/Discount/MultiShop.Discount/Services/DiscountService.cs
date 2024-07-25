using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    /// <summary>
    /// Dapper kullanarak Coupon CRUD İslemlerini gerceklestiren servis sınıfı 
    /// </summary>

    public class DiscountService : IDisCountService
    {

        // <summary>
        /// DiscountService constructor'ı, DapperContext bağımlılığını alır. yani biz burda Dependency Injection yaptık
        /// 
        /// </summary>
        /// <param name="context">DapperContext bağımlılığı</param>

        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context; // Enjekte ettigimiz DapperCOntext nesnesi sınıf icersindeki _context degiskenine atanır.
        }



        /// <summary>
        /// Yeni bir cupon olusturur asagıdaki metot
        /// </summary>
        /// <param name="createCouponDto">Olusturulacak Cupon bilgilerini iceren Dto'muz </param>
        /// <returns></returns>

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            //Asagıdaki String squery de sql sorgusu olusturuyoruz 

            String query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";

            // DynamicParameters nesnesi olusturulur.  DynamicParameters dapper ile uyumlu çalışarak sql sorgularında parametre kullanımını kolastirir. DynamicParameters, parametreli sorgular için bir konteyner görevi görür. Bu nesne, SQL sorgusunda kullanılacak parametreleri tutar.
            var parameters = new DynamicParameters();
            
            //Parametreler Sorguya eklenir . 

            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            // Veritabanı bağlantısı oluşturulur ve ExecuteAsync metodu ile sorgu çalıştırılır. Burada parameters nesnesi, sorguya eklenen parametrelerle birlikte kullanılır.
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }


        /// <summary>
        /// Belirten ID'YE sahip bir cupon siler 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task DeleteDiscountCouponAsync(int id)
        {

            string query = "Delete From Coupons where CouponId=@couponId";

            var parameters = new DynamicParameters();

            parameters.Add("couponId", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }

        }


        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupons";

            using (var connection = _context.CreateConnection())

            { 
               var values =await connection.QueryAsync<ResultDiscountCouponDto>(query);

                return values.ToList();
            
            }
        }



        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";

            var parameters= new DynamicParameters();

            parameters.Add("@couponId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }



        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate , ValidDate=@validDate where CouponId=@couponId";

            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        //Özet olarak ;  Güvenlik: DynamicParameters, SQL enjeksiyon saldırılarını önler. Ve dapper ile uyumlu calisarak parametreli sorguları kolayca yönetir.
       
       

    }

}

       
   
