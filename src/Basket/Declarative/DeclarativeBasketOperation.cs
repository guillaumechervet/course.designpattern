﻿using System;
using System.Collections.Immutable;

namespace Basket.Declarative
{
    public class DeclarativeBasketOperation
    {
        public static Func<ImmutableList<BasketLineArticle>, int> CalculateBasketAmount(Func<string, ArticleDatabase> getArticleFromDatabase)
        {
            return Calculate;
            int Calculate(ImmutableList<BasketLineArticle> basketLineArticles)
            {
                var amountTotal = 0;
                foreach (var basketLineArticle in basketLineArticles)
                {
                    var amount = 0;
                    var article = getArticleFromDatabase(basketLineArticle.Id);
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
                    amountTotal += amount * basketLineArticle.Number;
                }

                return amountTotal;
            }
        }

        public static ArticleDatabase GetArticleFromDatabaseMock(string id)
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
                default:
                    throw new NotImplementedException();
            }
        }
    }
}