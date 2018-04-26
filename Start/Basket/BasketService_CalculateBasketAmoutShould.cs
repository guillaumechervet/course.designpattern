using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Start.Basket.Imperative;
using Start.Introduction;

namespace Start.Basket
{

    [TestClass]
    public class BasketService_CalculateBasketAmoutShould
    {


        /// <summary>
        /// Don't delete, used by ShouldReturnCorrectType
        /// </summary>
        private static IEnumerable<object[]> ReusableTestDataProperty
        {
            get
            {
                return new[]
                       {   new object[] {new List<BasketLineArticle>
                               {
                                   new BasketLineArticle {Id = "1", Number = 12},
                                   new BasketLineArticle {Id = "2", Number = 1},
                                   new BasketLineArticle {Id = "3", Number = 4}
                               }
                           },
                           /*new object[] {new List<BasketLineArticle>
                               {
                                   new BasketLineArticle {Id = "1", Number = 4},
                                   new BasketLineArticle {Id = "2", Number = 2},
                                   new BasketLineArticle {Id = "3", Number = 1}
                               }
                           }*/
                       };
            }
        }


        [TestMethod]
        [DynamicData("ReusableTestDataProperty")]
        public void ReturnCorrectAmoutGivenBasket(IList<BasketLineArticle> lineArticles)
        {
            var amountTotal = ImperativeProgramming.CalculateBasketAmount(lineArticles);
           
            Assert.AreEqual(amountTotal, 61828);
        }
    }


    

}
