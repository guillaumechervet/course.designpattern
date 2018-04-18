using System;
using introduction.OrientedObject;
using introduction.OrientedObject.Infrastructure;
using Xunit;

namespace introduction.Declarative
{
    public class FunctionalTest
    {
        [Fact]
        public void PassingTest()
        {
            // Récépérer article depuis base de données
            var ligneArticles = new[]
            {
                new PanierLigneArticle {Id = "1", Number = 12},
                new PanierLigneArticle {Id = "2", Number = 1},
                new PanierLigneArticle {Id = "3", Number = 4}
            };

            var montantTotal = CalculerMontantPanier(ligneArticles);
    
            Assert.Equal(montantTotal, 60232);
        }
        
        public decimal CalculerMontantPanier(Func<string, ArticleDatabase> getArticleFromDatabase)
        {
            
            var montantTotal = 0;
            for (var i = 0; i < panierLigneArticles.Length; i++)
            {
                var ligneArticle = panierLigneArticles[i];
                var article = getArticleFromDatabase(ligneArticle.Id);
                switch (article.Category)
                {
                    case "food":
                        montantTotal += article.Price * 100 + article.Price * 12;
                        break;
                    case "electronic":
                        montantTotal += article.Price * 100 + article.Price * 20 + 4;
                        break;
                    case "desktop":
                        montantTotal += article.Price * 100 + article.Price * 20;
                        break;
                }
            }

            return montantTotal;
            
            int Calculer(PanierLigneArticle[] panierLigneArticles)
            {
                var montantTotal = 0;
                for (var i = 0; i < panierLigneArticles.Length; i++)
                {
                    var ligneArticle = panierLigneArticles[i];
                    var article = getArticleFromDatabase(ligneArticle.Id);
                    switch (article.Category)
                    {
                        case "food":
                            montantTotal += article.Price * 100 + article.Price * 12;
                            break;
                        case "electronic":
                            montantTotal += article.Price * 100 + article.Price * 20 + 4;
                            break;
                        case "desktop":
                            montantTotal += article.Price * 100 + article.Price * 20;
                            break;
                    }
                }

                return montantTotal;
            }   
        }

    }
}