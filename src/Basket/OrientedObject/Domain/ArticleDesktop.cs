using System;

namespace Basket.OrientedObject.Domain
{
    public class ArticleDesktop : ArticleBase
    {
        public ArticleDesktop(string id, int price, int stock, DateTime dateTime) : base(id, price, stock, dateTime)
        {
        }

        public override int CalculateAmout()
        {
            var price = Price;
            if (DateTime.Month == 12)
            {
                price = Price + 10;
            } else if(DateTime.Month ==1)
            {
                price = Price > 20 ? Price - 5 : Price;
            }

            const int tva = 20;
            return price * 100 + price * tva;
        }
    }
}
