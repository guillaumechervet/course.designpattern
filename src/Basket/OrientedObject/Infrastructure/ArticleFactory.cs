using System;
using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleFactory
    {
        public ArticleBase Create(ArticleDatabase articleDatabase)
        {
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

            return article;
        }
    }
}
