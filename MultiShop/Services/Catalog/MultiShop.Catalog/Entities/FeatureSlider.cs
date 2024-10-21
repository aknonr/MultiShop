using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // BsonRepresentation sınıfın icerisinde  Benzersiz BsonType olduğunu bildirmek icin bunun bir Id Olduğunu bildirmis olduk.

        public string FeatureSliderId { get; set; }

        public string Title { get; set; }

        public  string Description { get; set; }

        public  string ImageUrl { get; set; }

        public bool Status { get; set; }
    }
}
    