using Start.OrientedObject.Infrastructure;

namespace Start.OrientedObject
{
    public class PanierOperation
    {
        private readonly PanierService _panierService;

        public PanierOperation(PanierService panierService)
        {
            _panierService = panierService;
        }

        public int CalculerMontant(PanierLigneArticle[] panierLigneArticles)
        {
            var panier = _panierService.GetPanier(panierLigneArticles);
            return panier.CalculerMontant();
        }
    }
}