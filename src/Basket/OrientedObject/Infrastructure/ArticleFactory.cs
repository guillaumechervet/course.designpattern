using System;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleFactory
    {
        private readonly DateTime _dateTime;

        public ArticleFactory(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public ArticleBase Create(ArticleDatabase articleDatabase)
        {
            ArticleBase article;
            var articleDatabaseStock = articleDatabase.Stock;
            var articleDatabaseId = articleDatabase.Id;
            var articleDatabasePrice = articleDatabase.Price;
            switch (articleDatabase.Category)
            {
                case "food":
                    article = new ArticleFood(articleDatabaseId, articleDatabasePrice, articleDatabaseStock, _dateTime);
                    break;
                case "electronic":
                    article = new ArticleElectronic(articleDatabaseId, articleDatabasePrice, articleDatabaseStock, _dateTime);
                    break;
                case "desktop":
                    article = new ArticleDesktop(articleDatabaseId, articleDatabasePrice, articleDatabaseStock, _dateTime);
                    break;
                case "toy":
                    article = new ArticleToy(articleDatabaseId, articleDatabasePrice, articleDatabaseStock, _dateTime);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return article;
        }
    }
}
