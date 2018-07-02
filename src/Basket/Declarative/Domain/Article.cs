using System;

namespace Basket.Declarative.Domain
{
    public class Article
    {
        public int Price { get; set; }
        public string Category { get; set; }
    }

    public class ArticleExtention
    {
        public static Func<Article, int> ComputeArticle()
        {
            return Compute;
            int Compute(Article article)
            {
                var articlePrice = article.Price;
                var amount = 0;
                switch (article.Category)
                {
                    case "food":
                        amount = ArticleFood(articlePrice);
                        break;
                    case "electronic":
                        amount = ArticleElectronic(articlePrice);
                        break;
                    case "desktop":
                        amount = ArticleDesktop(articlePrice);
                        break;
                }

                return amount;
            }
        }

        private static int ArticleDesktop(int articlePrice)
        {
            return articlePrice * 100 + articlePrice * 20;
        }

        private static int ArticleElectronic(int articlePrice)
        {
            return articlePrice * 100 + articlePrice * 20 + 4;
        }

        private static int ArticleFood(int articlePrice)
        {
            return articlePrice * 100 + articlePrice * 12;
        }
    }
}