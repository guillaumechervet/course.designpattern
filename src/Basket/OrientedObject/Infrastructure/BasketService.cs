using System;
using System.Collections.Generic;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{

    public class BasketService
    {
        private readonly IArticleDatabase _articleDatabase;

        public BasketService(IArticleDatabase articleDatabase)
        {
            _articleDatabase = articleDatabase;
        }

        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            var basketLines = new List<BasketLine>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var articleDatabase = _articleDatabase.GetArticle(basketLineArticle.Id);

                ArticleBase article;
                switch (articleDatabase.Category)
                {
                    case "food":
                        article = new ArticleFood(articleDatabase.Id, articleDatabase.Price);
                        break;
                    case "electronic":
                        article = new ArticleElectronic(articleDatabase.Id, articleDatabase.Price);
                        break;
                    case "desktop":
                        article = new ArticleDesktop(articleDatabase.Id, articleDatabase.Price);
                        break;
                    case "toy":
                        article = new ArticleToy(articleDatabase.Id, articleDatabase.Price);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                
                basketLines.Add(new BasketLine(article, basketLineArticle.Number));
            }

            return new Domain.Basket(basketLines);
        }
    }
}