using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Basket.Infrastructure;
using Newtonsoft.Json;

namespace Basket
{
    public class BasketOperation
    {
        private readonly BasketService _basketService;

        public BasketOperation(BasketService basketService)
        {
            _basketService = basketService;
        }
        public int CalculateAmountTotal(IList<BasketLineArticle> basketLineArticles)
        {
            var basket = _basketService.GetBasket(basketLineArticles);
            return basket.TotalAmout();
        }
        
    }
}