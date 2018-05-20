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

            var basketLineDesktop = _basketLines.Where(bl => (bl is BasketLineDesktop)).Select(bl => (BasketLineDesktop) bl).FirstOrDefault();
            if (basketLineDesktop != null && basketLineDesktop.Number >= 7)
            {
                var basketLineToy = _basketLines.Where(bl => (bl is BasketLineToy)).FirstOrDefault();
                basketLineToy.NumberFree += 1;
            }

            foreach (var basketLine in _basketLines)
            {
                totalAmount += basketLine.CalculateAmount();
            }

            return totalAmount;
        }
    }
}