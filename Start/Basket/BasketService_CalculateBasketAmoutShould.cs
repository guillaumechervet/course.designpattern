using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.Basket.Imperative;
using Start.Introduction;

namespace Start.Basket
{

    [TestClass]
    public class BasketService_CalculateBasketAmoutShould
    {

        [TestMethod]
        public void ReturnCorrectAmoutGivenBasket()
        {
            // Récépérer article depuis base de données
            var lineArticles = new[]
            {
                new BasketLineArticle {Id = "1", Number = 12},
                new BasketLineArticle {Id = "2", Number = 1},
                new BasketLineArticle {Id = "3", Number = 4}
            };

            var amountTotal = ImperativeProgramming.CalculateBasketAmount(lineArticles);
           
          /*   var basketOperation = new BasketOperation(new BasketService(new DatabaseMock()));
             var amountTotal = panierOperation.CalculateAmount(ligneArticles);

            var amountTotal = BasketOperation.CalculateBasketAmount(BasketOperation.GetArticleFromDatabaseMock)(ligneArticles);
             */

            Assert.AreEqual(amountTotal, 60236);
        }
    }


    

}
