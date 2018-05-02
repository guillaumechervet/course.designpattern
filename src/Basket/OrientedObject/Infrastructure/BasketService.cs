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
                var article = new Article(articleDatabase.Id, articleDatabase.Price, articleDatabase.Category);
                basketLines.Add(new BasketLine(article, basketLineArticle.Number));
            }

            return new Domain.Basket(basketLines);
        }
    }
}