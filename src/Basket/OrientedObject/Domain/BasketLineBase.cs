namespace Basket.OrientedObject.Domain
{
    public abstract class BasketLineBase
    {
        public BasketLineBase(ArticleBase article, int number)
        {
            Article = article;
            Number = number;
        }

        public ArticleBase Article { get; internal set; }
        public int Number { get; internal set; }

        public abstract int CalculateAmount();
    }
}