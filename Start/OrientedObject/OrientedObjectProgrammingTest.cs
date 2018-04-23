using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.OrientedObject.Infrastructure;

namespace Start.OrientedObject
{
    [TestClass]
    public class OrientedObjectTest
    {
        [TestMethod]
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

            Assert.AreEqual(61828, montantTotal);
        }
    }
}