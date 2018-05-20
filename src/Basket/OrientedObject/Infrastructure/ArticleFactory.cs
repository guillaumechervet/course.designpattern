using System;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleFactory
    {
        public ArticleBase Create(ArticleDatabase articleDatabase)
        {
            ArticleBase article;
            var articleDatabaseStock = articleDatabase.Stock;
            var articleDatabaseId = articleDatabase.Id;
            var articleDatabasePrice = articleDatabase.Price;
            switch (articleDatabase.Category)
            {
                case "food":
                    article = new ArticleFood(articleDatabaseId, articleDatabasePrice, articleDatabaseStock);
                    break;
                case "electronic":
                    article = new ArticleElectronic(articleDatabaseId, articleDatabasePrice, articleDatabaseStock);
                    break;
                case "desktop":
                    article = new ArticleDesktop(articleDatabaseId, articleDatabasePrice, articleDatabaseStock);
                    break;
                case "toy":
                    article = new ArticleToy(articleDatabaseId, articleDatabasePrice, articleDatabaseStock);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return article;
        }
    }
}
