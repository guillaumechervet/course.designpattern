namespace Basket.OrientedObject.Domain
{
    public class ArticleFood : ArticleBase
    {
        public ArticleFood(string id, int price, int stock) : base(id, price, stock)
        {
        }

        public override int CalculateAmout()
        {
            var tva = 12;
            return Price * 100 + Price * tva;
        }
       
    }
}
