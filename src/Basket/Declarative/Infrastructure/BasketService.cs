using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Basket.Declarative.Domain;

namespace Basket.Declarative
{
    public class BasketService
    {
        public static Func<ImmutableList<BasketLineArticle>, Domain.Basket> GetBasket(Func<string, ArticleDatabase> getArticleFromDatabase)
        {
            return Local;
            Domain.Basket Local(ImmutableList<BasketLineArticle> basketLineArticles)
            {
                var list = new List<BasketLine>();
                foreach (var basketLineArticle in basketLineArticles)
                {
                    var article = getArticleFromDatabase(basketLineArticle.Id);
                    list.Add(new BasketLine()
                    {
                        Article = new Article() {Price = article.Price, Category = article.Category},
                        Number = basketLineArticle.Number
                    });
                }

                var basket = new Domain.Basket() {BasketLines = ImmutableList.CreateRange(list)};
                return basket;
            }
        }
    }
}