namespace Start.Basket.OrientedObject.Infrastructure
{
    public interface IDatabase
    {
        ArticleDatabase GetArticle(string id);
    }
}