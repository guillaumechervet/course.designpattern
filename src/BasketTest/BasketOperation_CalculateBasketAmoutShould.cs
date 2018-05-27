using System;
using System.Collections.Generic;
using Basket;
using Basket.OrientedObject.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasketOperation = Basket.OrientedObject.BasketOperation;

namespace BasketTest
{

    [TestClass]
    public class BasketOperation_CalculateBasketAmoutShould
    {
        public class BasketTest
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
            public DateTime DateTime { get; set; }
            public int ExpectedPrice { get; set; }
        }

        private static IEnumerable<object[]> Baskets
        {
            get
            {
                return new[]
                       {
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "2", Number = 1, Label = "Fridge electrolux"},
                                       new BasketLineArticle {Id = "3", Number = 4, Label = "Chair"}
                                   },
                                   DateTime = new DateTime(2018, 1, 1),
                                   ExpectedPrice = 77524}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "1", Number = 12, Label = "Banana"},
                                       new BasketLineArticle {Id = "4", Number = 2, Label = "Grumly"},
                                       new BasketLineArticle {Id = "3", Number = 4, Label = "Chair"}
                                   },
                                   DateTime = new DateTime(2018, 12, 1),
                                   ExpectedPrice = 40368}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "4", Number = 2, Label = "Grumly"},
                                       new BasketLineArticle {Id = "3", Number = 8, Label = "Chair"}
                                   },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 51360}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "4", Number = 10, Label = "Grumly"},
                                   },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 47200}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "1", Number = 21, Label = "Banana"},
                                   },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 2240}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "1", Number = 43, Label = "Banana"},
                                   },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 4592}
                           },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                               {
                                   new BasketLineArticle {Id = "1", Number = 12, Label = "Banana"},
                                   new BasketLineArticle {Id = "2", Number = 1, Label = "Fridge electrolux"},
                                   new BasketLineArticle {Id = "3", Number = 4, Label = "Chair"}
                               },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 84868}
                           },
                           new object[] {
                              new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                              {
                                 new BasketLineArticle {Id = "1", Number = 20, Label = "Banana"},
                                 new BasketLineArticle {Id = "3", Number = 6, Label = "Chair"}
                              },
                                  DateTime = new DateTime(2018, 2, 1),
                              ExpectedPrice = 37520}
                              },
                           new object[] {
                               new BasketTest(){ BasketLineArticles = new List<BasketLineArticle>
                                   {
                                       new BasketLineArticle {Id = "4", Number = 2, Label = "Grumy"},
                                   },
                                   DateTime = new DateTime(2018, 2, 1),
                                   ExpectedPrice = 8640}
                           },
                       };
            }
        }

        [TestMethod]
        [DynamicData("Baskets")]
        public void ReturnCorrectAmoutGivenBasket(BasketTest basketTest)
        {
            var logger = new LoggerMock();
            var basKetService = new BasketService(new ArticleDatabaseMock(), new ArticleFactory(new MockDateTime(basketTest.DateTime)), logger);
            var basketOperation = new BasketOperation(basKetService, logger);
            var amountTotal = basketOperation.CalculateAmount(basketTest.BasketLineArticles);
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }

        [TestMethod]
        public void ReturnCorrectAmoutGivenBasketLine()
        {
            var logger = new LoggerMock();
            var basketLineArticle = new BasketLineArticle {Id = "4", Number = 2, Label = "Grumy"};
            var basKetService = new BasketService(new ArticleDatabaseMock(), new ArticleFactory(new MockDateTime(new DateTime(2018, 2, 1))), logger);
            var basketOperation = new BasketOperation(basKetService, logger);
            var amountTotal = basketOperation.CalculateAmount(basketLineArticle);
            Assert.AreEqual(amountTotal, 8640);
        }

        [TestMethod]
        public void ThrowExeptionGivenUnavailableDatabase()
        {
            try
            {
                var logger = new LoggerMock();
                var basketLineArticle = new BasketLineArticle {Id = "4", Number = 2, Label = "Grumy"};
                var basKetService = new BasketService(new ArticleDatabaseMockException(), new ArticleFactory(new MockDateTime(new DateTime(2018, 2, 1))), logger);
                var basketOperation = new BasketOperation(basKetService, logger);
                var amountTotal = basketOperation.CalculateAmount(basketLineArticle);
                Assert.Fail();
            }
            catch (Exception ex)
            {}
        }
    }

}
