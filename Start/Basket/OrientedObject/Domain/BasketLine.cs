namespace Start.Basket.OrientedObject.Domain
{
    public class BasketLine
    {
        public BasketLine(Article article, int number)
        {
            Article = article;
            Number = number;
        }

        public Article Article { get; set; }
        public int Number { get; set; }
    }
}