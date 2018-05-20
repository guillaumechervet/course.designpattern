namespace Basket.OrientedObject.Domain
{
    public class BasketLine : BasketLineBase
    {

        public BasketLine(ArticleBase article, int number): base(article,number)
        {

        }

        public override int CalculateAmount()
        {
            return Article.CalculateAmout() * Number;
        }
    }
}