using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Results.AddressResults
{
    public class GetAddressByIdQueryResult
    {
        // Burda ID'ye göre adresslerimizi yapacak sınıf . Select*from where şartını yerine getirecek sınıfımız 
        public int AdressId { get; set; }

        public string UserId { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Detail { get; set; }

    }
}
