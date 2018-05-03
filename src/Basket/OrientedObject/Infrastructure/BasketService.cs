using System;
using System.Collections.Generic;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{

    public class BasketService
    {
        private readonly IArticleDatabase _articleDatabase;
        private readonly ArticleFactory _articleFactory;

        public BasketService(IArticleDatabase articleDatabase, ArticleFactory articleFactory)
        {
            _articleDatabase = articleDatabase;
            _articleFactory = articleFactory;
        }

        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            var basketLines = new List<BasketLine>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var basketLine = GetBasketLine(basketLineArticle);
                basketLines.Add(basketLine);
            }

            return new Domain.Basket(basketLines);
        }

        public BasketLine GetBasketLine(BasketLineArticle basketLineArticle)
        {
            var articleDatabase = _articleDatabase.GetArticle(basketLineArticle.Id);
            var article = _articleFactory.Create(articleDatabase);
            var basketLine = new BasketLine(article, basketLineArticle.Number);
            return basketLine;
        }

        
    }
}