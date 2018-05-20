
namespace Basket.OrientedObject.Domain
{
    public class BasketLineFood :  BasketLineBase
    {
        public BasketLineFood(ArticleBase article, int number) : base(article, number)
        {

        }

        public override int CalculateAmount()
        {
            var amount = 0;
            var numberFreeItem = 0;
            for (var numberInStock = 1; numberInStock <= Number; numberInStock++)
            {
                var currentStack = numberInStock - numberFreeItem * 20- numberFreeItem;
                if (currentStack != 21)
                {
                    amount += Article.CalculateAmout();
                }
                else
                {
                    numberFreeItem++;
                }
            }
            return amount;
        }
    }
}
