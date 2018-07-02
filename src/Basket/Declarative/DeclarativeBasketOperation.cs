using System;
using System.Collections.Immutable;

namespace Basket.Declarative
{
    public class DeclarativeBasketOperation
    {
        public static Func<ImmutableList<BasketLineArticle>, int> CalculateBasketAmount(Func<ImmutableList<BasketLineArticle>, Domain.Basket> getBasket, Func<Domain.Basket, int> computeBasket)
        {
            return Calculate;
            int Calculate(ImmutableList<BasketLineArticle> basketLineArticles)
            {
                var basket = getBasket(basketLineArticles);
                return computeBasket(basket);
            }
        }
    }
}