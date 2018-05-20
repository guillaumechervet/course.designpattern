using System;
using System.Collections.Generic;
using Basket.OrientedObject.Infrastructure;

namespace Basket.OrientedObject
{
    public class BasketOperation
    {
        private readonly BasketService _basketService;
        private readonly ILogger _logger;

        public BasketOperation(BasketService basketService, ILogger logger)
        {
            _basketService = basketService;
            _logger = logger;
        }

        public int CalculateAmount(IList<BasketLineArticle>  basketLineArticles)
        {
            _logger.LogInformation("Appel total panier réalisé");
            var basket = _basketService.GetBasket(basketLineArticles);
            return basket.CalculateAmount();
        }

        public int CalculateAmount(BasketLineArticle basketLineArticle)
        {
            _logger.LogInformation("Appel total ligne panier réalisé");
            var basket = _basketService.GetBasketLine(basketLineArticle);
            return basket.CalculateAmount();
        }

    }
}