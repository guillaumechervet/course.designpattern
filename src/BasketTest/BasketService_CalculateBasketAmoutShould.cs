using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Start.Basket;
using Start.Basket.Imperative;

namespace BasketTest
{

    [TestClass]
    public class BasketService_CalculateBasketAmoutShould
    {
        public class BasketTest
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
            public int ExpectedPrice { get; set; }
        }

        private static IEnumerable<object[]> ReusableTestDataProperty
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
        public void ReturnCorrectAmoutGivenBasket(BasketTest basketTest)
        {
            var amountTotal = ImperativeProgramming.CalculateBasketAmount(basketTest.BasketLineArticles);
            
            Assert.AreEqual(amountTotal, basketTest.ExpectedPrice);
        }

        /*  private static string GetAssemblyDirectory()
         {
             var codeBase = Assembly.GetExecutingAssembly().CodeBase;
             var uri = new UriBuilder(codeBase);
             var path = Uri.UnescapeDataString(uri.Path);
             return Path.GetDirectoryName(path);
         }

         public static string Load(string localPath)
         {
             var jsonPath = Path.Combine(GetAssemblyDirectory(), localPath);
             return File.ReadAllText(jsonPath);
         }

        [TestMethod]
         public void GenerateDababase()
         {
             var article1 = ImperativeProgramming.GetArticleFromDatabaseMock("1");
             var article2 = ImperativeProgramming.GetArticleFromDatabaseMock("2");
             var article3 = ImperativeProgramming.GetArticleFromDatabaseMock("3");

             var list = new List<ArticleDatabase>();
             list.Add(article1);
             list.Add(article2);
             list.Add(article3);

             File.WriteAllText(Path.Combine(GetAssemblyDirectory(), "article-database.json"), JsonConvert.SerializeObject(list, Formatting.Indented));
         }*/

    }




}
