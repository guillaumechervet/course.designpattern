﻿using System.Collections.Generic;

namespace Basket.OrientedObject.Domain
{
    public class Basket
    {
        private readonly IList<BasketLine> _basketLines;

        public Basket(IList<BasketLine> basketLiens)
        {
            _basketLines = basketLiens;
        }

        public int CalculateAmount()
        {
            var totalAmount = 0;
            foreach (var basketLine in _basketLines)
            {
                totalAmount += basketLine.CalculateAmount();
            }

            return totalAmount;
        }
    }
}