using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.OrientedObject;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : Controller
    {
        private BasketOperation _basketOperation;

        public BasketController(BasketOperation basketOperation)
        {
            _basketOperation = basketOperation;
        }

        public class BasketModel
        {
            public List<BasketLineArticle> BasketLineArticles { get; set; }
        }

        public class BasketResult
        {
            public int Total { get; set; }
        }

        [HttpPost]
        public BasketResult Post([FromBody]BasketModel basketModel)
        {
            return new BasketResult() { Total = _basketOperation.CalculateAmount(basketModel.BasketLineArticles) };
        }

    }
}
