using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Benzersiz olduğunu bildirmek için bunun bir Id Olduğunu bildirmiş olduk.

        public string CategoryID { get; set; }

        public string CategoryName { get; set; }


    }
}
