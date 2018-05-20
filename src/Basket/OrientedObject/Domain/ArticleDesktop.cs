namespace Basket.OrientedObject.Domain
{
    public class ArticleDesktop : ArticleBase
    {
        public ArticleDesktop(string id, int price, int stock) : base(id, price, stock)
        {
        }

        public override int CalculateAmout()
        {
            const int tva = 20;
            return Price * 100 + Price * tva;
        }
    }
}
