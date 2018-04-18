namespace introduction.OrientedObject.Infrastructure
{
    public interface IDatabase
    {
        ArticleDatabase GetArticle(string id);
    }
}