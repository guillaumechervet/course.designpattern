using System;

namespace BasketLib
{
    public class Mock
    {
        public static ArticleDatabase GetArticleFromMock(string articleId)
        {
            switch (articleId)
            {
                case "1":
                    return new ArticleDatabase() { Category = "food", Price = 1 };

                case "2":
                    return new ArticleDatabase() { Category = "electronic", Price = 500 };

                case "3":
                    return new ArticleDatabase() { Category = "desktop", Price = 49 };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
