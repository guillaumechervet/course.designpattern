using System;

namespace Start.Basket.OrientedObject.Infrastructure
{
    public class DatabaseMock : IDatabase
    {
        public ArticleDatabase GetArticle(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 35, Category = "food"};
                case "2":
                    return new ArticleDatabase {Id = "1", Price = 500, Stock = 20, Category = "electronic"};
                case "3":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 68, Category = "desktop"};
                default:
                    throw new NotImplementedException();
            }
        }
    }
}