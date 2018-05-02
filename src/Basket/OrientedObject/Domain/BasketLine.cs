namespace Basket.OrientedObject.Domain
{
    public class BasketLine
    {
        public BasketLine(Article article, int number)
        {
            Article = article;
            Number = number;
        }

        public Article Article { get; internal set; }
        public int Number { get; internal set; }

        public int CalculateAmount()
        {
            return Article.CalculateAmout() * Number;
        }

    }
}