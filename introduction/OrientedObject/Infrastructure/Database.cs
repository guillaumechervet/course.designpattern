using System;

namespace introduction.OrientedObject.Infrastructure
{
    public class DatabaseMock : IDatabase
    {
        public ArticleDatabase GetArticle(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 35, Type = "banana"};
                case "2":
                    return new ArticleDatabase {Id = "1", Price = 500, Stock = 20, Type = "frigo"};
                case "3":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 68, Type = "chaise"};
                default:
                    throw new NotImplementedException();
            }
        }
    }
}