using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

}
