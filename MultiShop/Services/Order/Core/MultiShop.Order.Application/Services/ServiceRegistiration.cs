using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Services
{
    public static class ServiceRegistiration
    {

        //Bunun yapılma sebebi Presentation katamnında controllerde Ordering Api ucunu program.cs 'de registiration yapmadık . ama onu uygulama için asagıdaki metoda yaptık. 
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
