using System;

namespace Basket.OrientedObject.Domain
{
    public class Article
    {
        public Article(string id, int price, string category)
        {
            Id = id;
            Category = category;
            Price = price;
        }

        public int Price { get; }
        public string Id { get; }
        public string Category { get; }

        public int CalculateAmout()
        {
            switch (Category)
            {
                case "food":
                    return Price * 100 + Price * 12;
                case "electronic":
                    return Price * 100 + Price * 20 + 4;
                case "desktop":
                    return Price * 100 + Price * 20;
                case "toy":
                    var newPrice = Price * 100 - Price * 30;
                    return (newPrice * 100 + newPrice * 20) / 100;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}