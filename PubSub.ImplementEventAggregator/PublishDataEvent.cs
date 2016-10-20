using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.PubSubEvents;
using PubSub.DTO;

namespace PubSub.ImplementEventAggregator
{
    public class PublishDataEvent : CompositePresentationEvent<StoreDetails>
    {
        private static readonly EventAggregator _eventAggregator;
        private static readonly PublishDataEvent _event;


        static PublishDataEvent()
        {

            _eventAggregator = new EventAggregator();
            _event = _eventAggregator.GetEvent<PublishDataEvent>();
        }

        public static PublishDataEvent Instance
        {
            get { return _event; }
        }
    }
}
