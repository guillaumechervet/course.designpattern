using System.Collections.Generic;
using Start.OrientedObject.Domain;

namespace Start.OrientedObject.Infrastructure
{
    public class PanierService
    {
        private readonly IDatabase _database;

        public PanierService(IDatabase database)
        {
            _database = database;
        }

        public Article GetArticle(string id)
        {
            var articleDatabase = _database.GetArticle(id);
            return new Article(id, articleDatabase.Price, articleDatabase.Category);
        }

        public Panier GetPanier(PanierLigneArticle[] panierLigneArticles)
        {
            var lignePaniers = new List<LignePanier>();
            foreach (var panierLigneArticle in panierLigneArticles)
            {
                var articleDatabase = _database.GetArticle(panierLigneArticle.Id);
                var article = new Article(articleDatabase.Id, articleDatabase.Price, articleDatabase.Category);
                lignePaniers.Add(new LignePanier(article, panierLigneArticle.Number));
            }

            return new Panier(lignePaniers);
        }
    }
}