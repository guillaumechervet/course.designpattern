#define MYTEST

using System;
using Xunit;

namespace introduction
{
    public class ImperativeProgrammingTest
    {
        public decimal CalculerMontant(PanierLigneArticle[] panierLigneArticles)
        {
            var montantTotal = 0;
            for (var i = 0; i < panierLigneArticles.Length; i++)
            {
                var ligneArticle = panierLigneArticles[i];
                var article = GetArticleFromDatabase(ligneArticle.Id);
                switch (article.Type)
                {
                    case "banana":
                        montantTotal += article.Price * 100 + article.Price * 12;
                        break;
                    case "frigo":
                        montantTotal += article.Price * 100 + article.Price * 20 + 4;
                        break;
                    case "chaise":
                        montantTotal += article.Price * 100 + article.Price * 20;
                        break;
                }
            }

            return montantTotal / 100;
        }

        public ArticleDatabase GetArticleFromDatabase(string id)
        {
            #if MYTEST
            switch (id)
            {
                case "1":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 35, Type = "banana"};
                case "2":
                    return new ArticleDatabase {Id = "1", Price = 500, Stock = 20, Type = "frigo"};
                case "3":
                    return new ArticleDatabase {Id = "1", Price = 1, Stock = 68, Type = "chaise"};
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

            var montantTotal = CalculerMontant(ligneArticles);

            Assert.Equal(montantTotal, 602);
        }
    }

    public struct PanierLigneArticle
    {
        public string Id { get; set; }
        public int Number { get; set; }
    }

    public struct ArticleDatabase
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}