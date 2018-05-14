using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Basket.Domain;
using Newtonsoft.Json;

namespace Basket.Infrastructure
{
    public class BasketService
    {
        private readonly IDatabase _database;

        public BasketService(IDatabase database)
        {
            _database = database;
        }

        public Domain.Basket GetBasket(IList<BasketLineArticle> basketLineArticles)
        {
            try { 
                var lines = new List<BasketLine>();
                foreach (var basketLineArticle in basketLineArticles)
                {
                    var article = _database.GetArticleFromDatabase(basketLineArticle.Id);
                    lines.Add(new BasketLine(new Article(article.Id,article.Category,article.Price, article.Label ), basketLineArticle.Number));

                }
                var basket = new Domain.Basket(lines);
                return basket;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
