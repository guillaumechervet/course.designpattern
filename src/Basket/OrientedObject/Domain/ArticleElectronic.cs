namespace Basket.OrientedObject.Domain
{
    public class ArticleElectronic : ArticleBase
    {
        public ArticleElectronic(string id, int price, int stock) : base(id, price, stock)
        {
        }

        public override int CalculateAmout()
        {
            var tva = 20;
            return Price * 100 + Price * tva + 4;
        }
    }
}
