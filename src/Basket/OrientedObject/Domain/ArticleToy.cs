namespace Basket.OrientedObject.Domain
{
    public class ArticleToy : ArticleBase
    {
        public ArticleToy(string id, int price) : base(id, price)
        {
        }

        public override string Category
        {
            get { return "toy"; }
        }

        public override int CalculateAmout()
        {
            var newPrice = Price -3 ;
            return newPrice * 100 + newPrice * 20;
        }
    }
}
