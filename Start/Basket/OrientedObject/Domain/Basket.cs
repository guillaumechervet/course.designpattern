using System.Collections.Generic;

namespace Start.OrientedObject.Domain
{
    public class Basket
    {
        private readonly IList<BasketLine> _lignePaniers;

        public Basket(IList<BasketLine> lignePaniers)
        {
            _lignePaniers = lignePaniers;
        }

        public int CalculateAmount()
        {
            var montantTotal = 0;
            foreach (var lignePanier in _lignePaniers)
            {
                montantTotal += lignePanier.Article.CalculateAmout() * lignePanier.Number;
            }

            return montantTotal;
        }
    }
}