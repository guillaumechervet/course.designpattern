using System;

namespace Basket.OrientedObject.Domain
{
    public class ArticleFood : ArticleBase
    {
        public ArticleFood(string id, int price, int stock, DateTime dateTime) : base(id, price, stock, dateTime)
        {
        }

        public override int CalculateAmout()
        {
            var price = DateTime.Month == 12 ? Price * 2 : Price;
            var tva = 12;
            return price * 100 + price * tva;
        }
       
    }
}
