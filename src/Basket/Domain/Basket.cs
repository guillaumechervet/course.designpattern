using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain
{
    public class Basket
    {
        private readonly IList<BasketLine> _basketLines;

        public Basket(IList<BasketLine> basketLines)
        {
            _basketLines = basketLines;
        }

        public int TotalAmout()
        {
            var totalAmout = 0;
            foreach (var basketLine in _basketLines)
            {
                totalAmout += basketLine.TotalAmount();
            }
            return totalAmout;
        }

    }
}
