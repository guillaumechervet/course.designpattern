using System;

namespace introduction.OrientedObject.Domain
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

        public int CalculerMontant()
        {
            switch (Category)
            {
                case "banana":
                    return Price * 100 + Price * 12;
                case "frigo":
                    return Price * 100 + Price * 20 + 4;
                case "chaise":
                    return Price * 100 + Price * 20;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}