using System;

namespace Basket.OrientedObject.Domain
{
    public class ArticleElectronic : ArticleBase
    {
        public ArticleElectronic(string id, int price, int stock, DateTime dateTime) : base(id, price, stock, dateTime)
        {
        }

        public override int CalculateAmout()
        {
            var price = DateTime.Month == 1 && Price > 300 ? Price - 30 : Price;
            var tva = 20;
            return price * 100 + price * tva + 4;
        }
    }
}
