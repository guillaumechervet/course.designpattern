namespace Basket.Domain
{
    public class Article
    {
        public string Id { get; }
        public string Category { get; }
        public int Price { get; }
        public string Label { get; }

        public Article(string id, string category, int price, string label)
        {
            Id = id;
            Category = category;
            Price = price;
            Label = label;
        }

        public int Total()
        {
            var amount = 0;
            switch (Category)
            {
                case "food":
                    amount += Price * 100 + Price * 12;
                    break;
                case "electronic":
                    amount += Price * 100 + Price * 20 + 4;
                    break;
                case "desktop":
                    amount += Price * 100 + Price * 20;
                    break;
            }

            return amount;
        }
    }
}