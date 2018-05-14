using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Domain
{
    public class BasketLine
    {
        private Article Article { get; }
        private int Number { get; }

        internal BasketLine(Article article, int number)
        {
            Article = article;
            Number = number;
        }


        public int TotalAmount()
        {
            return Number * Article.Total();
        }
    }
}
