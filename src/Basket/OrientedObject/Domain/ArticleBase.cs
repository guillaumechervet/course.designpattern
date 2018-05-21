using System;

namespace Basket.OrientedObject.Domain
{
    public abstract class ArticleBase
    {
        private readonly DateTime _dateTime;

        public ArticleBase(string id, int price, int stock, DateTime dateTime)
        {
            _dateTime = dateTime;
            Stock = stock;
            Id = id;
            Price = price;
        }

        public int Price { get; }
        public string Id { get; }
        public int Stock { get; }

        protected DateTime DateTime
        {
            get { return _dateTime; }
        }

        public abstract int CalculateAmout();
    }

}