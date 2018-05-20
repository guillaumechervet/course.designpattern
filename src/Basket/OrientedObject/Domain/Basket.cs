using System.Collections.Generic;
using System.Linq;

namespace Basket.OrientedObject.Domain
{
    public class Basket
    {
        private readonly IList<BasketLineBase> _basketLines;

        public Basket(IList<BasketLineBase> basketLiens)
        {
            _basketLines = basketLiens;
        }

        public int CalculateAmount()
        {
            var totalAmount = 0;

//            var basketLineDesktop = _basketLines.Where(bl => bl is BasketLineDesktop).FirstOrDefault();
            foreach (var basketLine in _basketLines)
            {
               /* if (basketLineDesktop != null)
                {
                    if (basketLineDesktop.Number >=7)
                    {

                    }
                }*/

                totalAmount += basketLine.CalculateAmount();
            }

            return totalAmount;
        }
    }
}