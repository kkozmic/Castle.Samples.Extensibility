using System;

namespace EventBrokerSample.UI.UI
{
    public class DateTimeMessage
    {
        public DateTime DateAndTime { get; private set; }

        public DateTimeMessage(DateTime dateAndTime)
        {
            DateAndTime = dateAndTime;
        }
    }
}