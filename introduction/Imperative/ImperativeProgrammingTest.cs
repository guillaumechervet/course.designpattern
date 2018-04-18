#define MYTEST

using System;
using Xunit;

namespace introduction.Imperative
{
    public class ImperativeProgrammingTest
    {
        public decimal CalculerMontantPanier(PanierLigneArticle[] panierLigneArticles)
        {
            var montantTotal = 0;
            for (var i = 0; i < panierLigneArticles.Length; i++)
            {
                var ligneArticle = panierLigneArticles[i];
                var article = GetArticleFromDatabase(ligneArticle.Id);
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

        public ArticleDatabase GetArticleFromDatabase(string id)
        {
#if MYTEST
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
#else
// TODO request a real database
            throw new NotImplementedException();
            #endif
        }

        [Fact]
        public void test()
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
    }
}