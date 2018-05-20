namespace Basket.OrientedObject.Domain
{
    public abstract class BasketLineBase
    {
        public BasketLineBase(ArticleBase article, int number)
        {
            Article = article;
            Number = number;
        }

        public ArticleBase Article { get; protected set; }
        public int Number { get; protected set; }

        public abstract int CalculateAmount();
    }
}