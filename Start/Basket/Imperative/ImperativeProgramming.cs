using System;
using System.Collections.Generic;

namespace Start.Basket.Imperative
{
    public class ImperativeProgramming
    {

        public static decimal CalculateBasketAmount(IList<BasketLineArticle> basketLineArticles)
        {
            var totalAmount = 0;
            foreach (var basketLineArticle in basketLineArticles)
            {
                var article = GetArticleFromDatabase(basketLineArticle.Id);
                var amount = 0;
                switch (article.Category)
                {
                    case "food":
                        amount += article.Price * 100 + article.Price * 12;
                        break;
                    case "electronic":
                        amount += article.Price * 100 + article.Price * 20 + 4;
                        break;
                    case "desktop":
                        amount += article.Price * 100 + article.Price * 20;
                        break;
                }
                totalAmount += amount * basketLineArticle.Number;
            }
            return totalAmount;
        }

        public static ArticleDatabase GetArticleFromDatabase(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 35, Type = "banana", Category = "food"};
                case "2":
                    return new ArticleDatabase
                    {
                        Id = "1",
                        Price = 500,
                        Stock = 20,
                        Type = "frigo",
                        Category = "electronic"
                    };
                case "3":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 68, Type = "chaise", Category = "desktop"};
                default:
                    throw new NotImplementedException();
            }
        }

        /*public static UserDatabase GetUserFromDatabase(string id)
        {
            switch (id)
            {
                case "1":
                    return new UserDatabase {Id = "1", FirstName="Guillaume", BirthDate= new DateTime(1983, 31, 8)};
                default:
                    throw new NotImplementedException();
            }
        }*/

    }
}