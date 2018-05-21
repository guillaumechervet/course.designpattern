using Basket.OrientedObject.Domain;

namespace Basket.OrientedObject.Infrastructure
{
    public class BasketLineFactory
    {
        public static BasketLineBase Create(BasketLineArticle basketLineArticle, ArticleDatabase articleDatabase,
            ArticleBase article)
        {
            BasketLineBase basketLine;

            switch (articleDatabase.Category)
            {
                case "food":
                    basketLine = new BasketLineFood(article, basketLineArticle.Number);
                    break;
                case "toy":
                    basketLine = new BasketLineToy(article, basketLineArticle.Number);
                    break;
                case "desktop":
                    basketLine = new BasketLineDesktop(article, basketLineArticle.Number);
                    break;
                default:
                    basketLine = new BasketLine(article, basketLineArticle.Number);
                    break;
            }

            return basketLine;
        }
    }
}