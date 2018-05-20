using System;
using System.Collections.Generic;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{

    public class BasketService
    {
        private readonly IArticleDatabase _articleDatabase;
        private readonly ArticleFactory _articleFactory;
        private readonly ILogger _logger;

        public BasketService(IArticleDatabase articleDatabase, ArticleFactory articleFactory, ILogger logger)
        {
            _articleDatabase = articleDatabase;
            _articleFactory = articleFactory;
            _logger = logger;
        }

        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            var basketLines = new List<BasketLineBase>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var basketLine = GetBasketLine(basketLineArticle);
                basketLines.Add(basketLine);
            }

            return new Domain.Basket(basketLines);
        }

        public BasketLineBase GetBasketLine(BasketLineArticle basketLineArticle)
        {
            try
            {
                var articleDatabase = _articleDatabase.GetArticle(basketLineArticle.Id);
                var article = _articleFactory.Create(articleDatabase);
                BasketLineBase basketLine; 

                switch (articleDatabase.Category)
                {
                    case "food":
                        basketLine = new BasketLineFood(article, basketLineArticle.Number);
                        break;
                    default:
                        basketLine = new BasketLine(article, basketLineArticle.Number);
                        break;
                }
               
                return basketLine;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "problème lors de la récupération des données article");
                throw ex;
            }
        }

        
    }
}