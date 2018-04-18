using System;
using Xunit;

namespace introduction
{
    public class ImperativeProgrammingTest
    {
        public int CalculerMontant(LigneArticle[] ligneArticles)
        {
            var montantTotal = 0;
            for (var i = 0; i < ligneArticles.Length; i++)
            {
                var ligneArticle = ligneArticles[i];
                var article = RecupererArticle(ligneArticle.Id);
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

            return montantTotal;
        }

        public Article RecupererArticle(string id)
        {
            switch (id)
            {
                case "1":
                    return new Article {Id = "1", Price = 1, Stock = 35, Type = "banana"};
                case "2":
                    return new Article {Id = "1", Price = 500, Stock = 20, Type = "frigo"};
                case "3":
                    return new Article {Id = "1", Price = 1, Stock = 68, Type = "chaise"};
                default:
                    throw new NotImplementedException();
            }
        }

        [Fact]
        public void test()
        {
            // Récépérer article depuis base de données
            var ligneArticles = new[]
            {
                new LigneArticle {Id = "1", Number = 12},
                new LigneArticle {Id = "2", Number = 1},
                new LigneArticle {Id = "3", Number = 4}
            };

            var montantTotal = CalculerMontant(ligneArticles);

            Assert.Equal(montantTotal, 4000);
        }
    }

    public struct LigneArticle
    {
        public string Id { get; set; }
        public int Number { get; set; }
    }

    public struct Article
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}