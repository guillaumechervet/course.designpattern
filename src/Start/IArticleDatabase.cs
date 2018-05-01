namespace Start.Basket.OrientedObject.Infrastructure
{
    public interface IArticleDatabase
    {
        Basket.ArticleDatabase GetArticle(string id);
    }
}