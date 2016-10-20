using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;

namespace PubSub.ImplementEventAggregator
{
    public class ManageConnectionEvent : CompositePresentationEvent<bool>
    {
        private static readonly EventAggregator _eventAggregator;
        private static readonly ManageConnectionEvent _event;


        static ManageConnectionEvent()
        {

            _eventAggregator = new EventAggregator();
            _event = _eventAggregator.GetEvent<ManageConnectionEvent>();
        }

        public static ManageConnectionEvent Instance
        {
            get { return _event; }
        }
    }
}
