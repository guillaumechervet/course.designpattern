namespace Basket.OrientedObject.Domain
{
    public class ArticleToy : ArticleBase
    {
        public ArticleToy(string id, int price, int stock) : base(id, price, stock)
        {
        }

        public override int CalculateAmout()
        {
            var newPrice = Price -3 ;
            var tva = 20;
            return newPrice * 100 + newPrice * tva;
        }
    }
}
