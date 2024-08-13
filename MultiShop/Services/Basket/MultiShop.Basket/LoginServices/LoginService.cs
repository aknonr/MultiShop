namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpcontextAccessor = contextAccessor;
        }

        //Get user ıd isimli propertymizie service sınıfı aracılığıyla sub key'in aracılığıyla token yakalayıp sepet ile ilişkili hale getirecez.
        public string GetUserId => _httpcontextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
