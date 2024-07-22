using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // BsonRepresentation sınıfın icerisinde  Benzersiz BsonType olduğunu bildirmek icin bunun bir Id Olduğunu bildirmis olduk.

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }


    }
}
