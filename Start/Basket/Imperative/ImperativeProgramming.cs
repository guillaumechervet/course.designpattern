using System;

namespace Start.Basket.Imperative
{
    public class ImperativeProgramming
    {

        public static decimal CalculateBasketAmount(BasketLineArticle[] basketLineArticles, string userId)
        {
            var totalAmount = 0;
            for (var i = 0; i < basketLineArticles.Length; i++)
            {
                var lineArticle = basketLineArticles[i];
                var article = GetArticleFromDatabase(lineArticle.Id);
                switch (article.Category)
                {
                    case "food":
                        totalAmount += article.Price * 100 + article.Price * 12;
                        break;
                    case "electronic":
                        totalAmount += article.Price * 100 + article.Price * 20 + 4;
                        break;
                    case "desktop":
                        totalAmount += article.Price * 100 + article.Price * 20;
                        break;
                }
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

         public static ArticleDatabase GetUserFromDatabase(string id)
        {
            switch (id)
            {
                case "1":
                    return new UserDatabase {Id = "1", FirstName="Guillaume", BirthDate= new DateTime(1983, 31, 8)};
                default:
                    throw new NotImplementedException();
            }
        }

    }
}