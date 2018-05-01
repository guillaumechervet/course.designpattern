using System;
using System.Collections.Generic;
using System.Text;

namespace Start.Basket.OrientedObject.Infrastructure
{
    public class ArticleMock : IDatabase
    {

        public Basket.ArticleDatabase GetArticle(string id)
        {
            switch (id)
            {
                case "1":
                    return new Basket.ArticleDatabase { Id = "1", Price = 1, Stock = 35, Label = "banana", Category = "food" };
                case "2":
                    return new Basket.ArticleDatabase
                    {
                        Id = "1",
                        Price = 500,
                        Stock = 20,
                        Label = "frigo",
                        Category = "electronic"
                    };
                case "3":
                    return new Basket.ArticleDatabase { Id = "1", Price = 1, Stock = 68, Label = "chaise", Category = "desktop" };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
