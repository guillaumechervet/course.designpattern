using System;

namespace Basket.Declarative.Domain
{
    public class BasketLine {
        public int Number { get; set; }
        public Article Article { get; set; }
    }

    public class BasketLineExtention
    {
        public static Func<Domain.BasketLine, int> ComputeBasketLine(Func<Article, int> computeArticle)
        {
            return Compute;
            int Compute(Domain.BasketLine basketLine)
            {
                return basketLine.Number * computeArticle(basketLine.Article);
            }
        }
    }
}