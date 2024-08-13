namespace MultiShop.Basket.Dtos
{
    public class BasketItemDto
    {
        //Verileri Catalog mikroservice'den çekecez. Ve orda veri tipi strind'di o yüzden bizde int yerine string yaptık 

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }  //Kaç adet alındığı

        public  decimal Price { get; set; }


    }
}
