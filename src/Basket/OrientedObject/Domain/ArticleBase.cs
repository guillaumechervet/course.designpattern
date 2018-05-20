namespace Basket.OrientedObject.Domain
{
    public abstract class ArticleBase
    {
        public ArticleBase(string id, int price, int stock)
        {
            Stock = stock;
            Id = id;
            Price = price;
        }

        public int Price { get; }
        public string Id { get; }
        public int Stock { get; }

        public abstract int CalculateAmout();
    }

}