namespace Basket.OrientedObject.Domain
{
    public class BasketLine
    {
        public BasketLine(ArticleBase article, int number)
        {
            Article = article;
            Number = number;
        }

        public ArticleBase Article { get; internal set; }
        public int Number { get; internal set; }

        public int CalculateAmount()
        {
            return Article.CalculateAmout() * Number;
        }

    }
}