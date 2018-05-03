using System;

namespace Basket.OrientedObject.Infrastructure
{
    public class ArticleDatabaseMockException : IArticleDatabase
    {

        public ArticleDatabase GetArticle(string id)
        {
            throw new Exception("database error");
        }
    }
}
