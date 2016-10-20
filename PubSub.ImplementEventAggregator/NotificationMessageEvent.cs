using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;

namespace PubSub.ImplementEventAggregator
{
    public class NotificationMessageEvent: CompositePresentationEvent<string>
    {
        private static readonly EventAggregator _eventAggregator;
        private static readonly NotificationMessageEvent _event;

   

        static NotificationMessageEvent()
        {

            _eventAggregator = new EventAggregator();
            _event = _eventAggregator.GetEvent<NotificationMessageEvent>();
        }

        public static NotificationMessageEvent Instance
        {
            get { return _event; }
        }
    }
}
