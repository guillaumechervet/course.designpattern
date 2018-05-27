using System;

namespace Basket
{
    public class MockDateTime : IDateTime
    {
        private readonly DateTime _dateTime;

        public MockDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime Now
        {
            get { return _dateTime; }
        }
    }
}
