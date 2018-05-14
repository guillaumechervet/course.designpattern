using Basket;

public interface IDatabase
{
    ArticleDatabase GetArticleFromDatabase(string id);
}