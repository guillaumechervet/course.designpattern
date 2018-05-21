using System;

namespace Basket.OrientedObject.Domain
{
    public class ArticleToy : ArticleBase
    {
        public ArticleToy(string id, int price, int stock, DateTime dateTime) : base(id, price, stock, dateTime)
        {
        }

        public override int CalculateAmout()
        {
            var newPrice = Price -3;
            var price = DateTime.Month == 12 ? newPrice + 3 : newPrice;
            var tva = 20;
            return price * 100 + price * tva;
        }
    }
}
