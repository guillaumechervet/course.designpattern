using System.Collections.Generic;

namespace introduction.OrientedObject.Domain
{
    public class Panier
    {
        private readonly IList<LignePanier> _lignePaniers;

        public Panier(IList<LignePanier> lignePaniers)
        {
            _lignePaniers = lignePaniers;
        }

        public int CalculerMontant()
        {
            var montantTotal = 0;
            foreach (var lignePanier in _lignePaniers) montantTotal += lignePanier.Article.Price * lignePanier.Number;

            return montantTotal;
        }
    }
}