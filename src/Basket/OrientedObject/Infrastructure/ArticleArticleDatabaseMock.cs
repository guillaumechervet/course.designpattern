﻿using System;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleArticleDatabaseMock : IArticleDatabase
    {

        public ArticleDatabase GetArticle(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase { Id = "1", Price = 1, Stock = 35, Label = "banana", Category = "food" };
                case "2":
                    return new ArticleDatabase
                    {
                        Id = "2",
                        Price = 500,
                        Stock = 20,
                        Label = "frigo",
                        Category = "electronic"
                    };
                case "3":
                    return new ArticleDatabase { Id = "3", Price = 49, Stock = 68, Label = "chaise", Category = "desktop" };
                case "4":
                    return new ArticleDatabase { Id = "4", Price = 39, Stock = 55, Label = "grumly", Category = "toy" };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
