using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Basket;
using Basket.Declarative;
using Basket.OrientedObject.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasketOperation = Basket.OrientedObject.BasketOperation;
using BasketService = Basket.OrientedObject.Infrastructure.BasketService;

namespace BasketTest
{

    [TestClass]
    public class BasketOperation_CalculateBasketAmoutShould
    {
        public class BasketTest
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
            public int ExpectedPrice { get; set; }
        }

        private static IEnumerable<object[]> Baskets
        {
            get
            {
                return new[]
                       {   new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                               {
                                   new BasketLineArticle {Id = "1", Number = 12, Label = "Banana"},
                                   new BasketLineArticle {Id = "2", Number = 1, Label = "Fridge electrolux"},
                                   new BasketLineArticle {Id = "3", Number = 4, Label = "Chair"}
                               },
                                   ExpectedPrice = 84868}
                           },
                           new object[] {
                              new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                              {
                                 new BasketLineArticle {Id = "1", Number = 20, Label = "Banana"},
                                 new BasketLineArticle {Id = "3", Number = 6, Label = "Chair"}
                              },
                              ExpectedPrice = 37520}
                              },
                       };
            }
        }

        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasketDeclarative(BasketTest basketTest)
        {
            var getBasket =
                Basket.Declarative.BasketService.GetBasket(Basket.Declarative.Database.GetArticleFromDatabaseMock);
            var computeBasket = Basket.Declarative.Domain.BasketExtention.ComputeBasket(
                Basket.Declarative.Domain.BasketLineExtention.ComputeBasketLine(Basket.Declarative.Domain.ArticleExtention.ComputeArticle()));

                
            var amountTotal = DeclarativeBasketOperation.CalculateBasketAmount(getBasket, computeBasket)(ImmutableList.CreateRange(basketTest.BasketLineArticles));
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }

        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasketObject(BasketTest basketTest)
        {
            var logger = new LoggerMock();
            var basKetService = new BasketService(new ArticleDatabaseMock(), new ArticleFactory(), logger);
            var basketOperation = new BasketOperation(basKetService, logger);
            var amountTotal = basketOperation.CalculateAmout(basketTest.BasketLineArticles);
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }
    }

}
