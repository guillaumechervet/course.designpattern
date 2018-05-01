using Start.Basket.OrientedObject.Infrastructure;

namespace Start.Basket.OrientedObject
{
    public class BasketOperation
    {
        private readonly BasketService _basketService;

        public BasketOperation(BasketService basketService)
        {
            _basketService = basketService;
        }

        public int CalculateAmout(BasketLineArticle[] basketLineArticles)
        {
            var basket = _basketService.GetBasket(basketLineArticles);
            return basket.CalculateAmount();
        }
    }
}