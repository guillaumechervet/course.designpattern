using System.Collections.Generic;
using Start.Basket.OrientedObject.Domain;

namespace Start.Basket.OrientedObject.Infrastructure
{
    public class BasketService
    {
        private readonly IDatabase _database;

        public BasketService(IDatabase database)
        {
            _database = database;
        }

        public Domain.Basket GetBasket(BasketLineArticle[] basketLineArticles)
        {
            var basketLines = new List<BasketLine>();
            foreach (var basketLineArticle in basketLineArticles)
            {
                var articleDatabase = _database.GetArticle(basketLineArticle.Id);
                var article = new Article(articleDatabase.Id, articleDatabase.Price, articleDatabase.Category);
                basketLines.Add(new BasketLine(article, basketLineArticle.Number));
            }

            return new Domain.Basket(basketLines);
        }
    }
}