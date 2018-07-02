using System;
using System.Collections.Immutable;

namespace Basket.Declarative.Domain
{
    public class Basket
    {
        public ImmutableList<BasketLine> BasketLines { get; set; }
    }

    public class BasketExtention
    {
        public static Func<Domain.Basket, int> ComputeBasket(Func<BasketLine, int> computeBasketLine)
        {
            return Compute;
            int Compute(Domain.Basket basket)
            {
                var total = 0;
                foreach (var basketLine in basket.BasketLines)
                {
                    total += computeBasketLine(basketLine);
                }

                return total;
            }
        }
    }


}
