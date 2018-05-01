using System;
using System.Collections.Generic;
using System.Text;
using Start.Basket.OrientedObject.Domain;

namespace Start.Basket.OrientedObject.Infrastructure
{
    public class ArticleService
    {
        private readonly IArticleDatabase _articleDatabase;

        public ArticleService(IArticleDatabase articleDatabase)
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
