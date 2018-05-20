namespace Basket.OrientedObject.Domain
{
    public class ArticleDesktop : ArticleBase
    {
        public ArticleDesktop(string id, int price) : base(id, price)
        {
        }

        public override int CalculateAmout()
        {
            const int tva = 20;
            return Price * 100 + Price * tva;
        }
    }
}
