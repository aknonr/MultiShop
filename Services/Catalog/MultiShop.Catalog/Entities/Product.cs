﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageUrl { get; set; }

        public string ProductDescription { get; set; }

        public string CategoryId { get; set; }



        [BsonIgnore]
        public Category Category { get; set; }

        // BsonIgnore] nedir?

        // [BsonIgnore], MongoDB için belge ve nesne eşleştirme işlemlerinde kullanılan bir özniteliktir.Bu öznitelik, belirli bir özelliğin MongoDB belgesine dönüştürülürken veya belgeden nesneye dönüştürülürken dikkate alınmamasını sağlar, yani MongoDB tarafında depolanmaz veya yüklenmez.

        //[BsonIgnore] kullanmassak ne olur?
        //[BsonIgnore] kullanmazsanız, Category özelliği MongoDB belgesine dönüştürülürken dikkate alınacak ve belgelere dahil edilecektir.Ancak, Category özelliği veri tabanında bir alanı temsil etmiyor, bu nedenle MongoDB'de gereksiz bir alana dönüşecektir.


        //Bu durum, gereksiz veri saklamak ve gereksiz bellek kullanımına neden olabilir.Ayrıca, Category özelliğinin değerlerini güncelleme veya sorgulama gibi işlemleri gerçekleştirmek istediğinizde, MongoDB tarafında ekstra iş yükü oluşturabilir.


        //Bu nedenle, Category özelliğinin doğrudan MongoDB belgesine dönüştürülmemesi için[BsonIgnore] kullanmanız önerilir.Bu, Category özelliğinin MongoDB belgesine dahil edilmemesini sağlar ve veri tabanında gereksiz bir alan oluşturulmaz. Bu, genellikle daha temiz ve etkili bir MongoDB veritabanı tasarımına yol açar.
     




    }
}
