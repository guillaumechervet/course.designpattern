using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api
{
    public class MockDateTime : IDateTime
    {
        private readonly DateTime _dateTime;

        MockDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime Now
        {
            get { return _dateTime; }
        }
    }
}
