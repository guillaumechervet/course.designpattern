using System;
using System.Collections.Immutable;
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
        var ligneArticles = ImmutableList.Create(
                new PanierLigneArticle {Id = "1", Number = 12},
                new PanierLigneArticle {Id = "2", Number = 1},
                new PanierLigneArticle {Id = "3", Number = 4}
            );

            var montantTotal = CalculerMontantPanier(GetArticleFromDatabaseMock)(ligneArticles);
    
            Assert.Equal(montantTotal, 60232);
        }
        
        public Func<ImmutableList<PanierLigneArticle>, int> CalculerMontantPanier(Func<string, ArticleDatabase> getArticleFromDatabase)
        {
            return Calculer;
            int Calculer(ImmutableList<PanierLigneArticle> panierLigneArticles)
            {
                var montantTotal = 0;
                foreach (var ligneArticle in panierLigneArticles)
                {
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
        
        public ArticleDatabase GetArticleFromDatabaseMock(string id)
        {
            switch (id)
            {
                case "1":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 35, Type = "banana", Category = "food"};
                case "2":
                    return new ArticleDatabase
                    {
                        Id = "1",
                        Price = 500,
                        Stock = 20,
                        Type = "frigo",
                        Category = "electronic"
                    };
                case "3":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 68, Type = "chaise", Category = "desktop"};
                default:
                    throw new NotImplementedException();
            }
        }

    }
}