
namespace Basket.OrientedObject.Domain
{
    public class BasketLineToy :  BasketLineBase
    {
        public BasketLineToy(ArticleBase article, int number) : base(article, number)
        {

        }

        public override int CalculateAmount()
        {
            var amount = 0;
            var stock = Article.Stock;
            for (var numberInStock = 1; numberInStock <= Number; numberInStock++)
            {
                amount += Article.CalculateAmout();
                if (stock < 50)
                {
                    amount += 10 * 100;
                }
                stock -= 1;
            }
            return amount;
        }
    }
}
