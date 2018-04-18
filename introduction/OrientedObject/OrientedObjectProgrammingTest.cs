using introduction.OrientedObject.Infrastructure;
using Xunit;

namespace introduction.OrientedObject
{
    public class OrientedObjectTest
    {
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

            var panierOperation = new PanierOperation(new PanierService(new DatabaseMock()));
            var montantTotal = panierOperation.CalculerMontant(ligneArticles);

            Assert.Equal(montantTotal, 60232);
        }
    }
}