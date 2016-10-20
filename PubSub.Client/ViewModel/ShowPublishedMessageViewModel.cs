using Microsoft.Practices.Prism.ViewModel;
using PubSub.ImplementEventAggregator;

namespace PubSub.Client.ViewModel
{
    public class ShowPublishedMessageViewModel: NotificationObject
    {
        public ShowPublishedMessageViewModel()
        {
            InitializePublisherSubscribersWorkFlow.SetPublisherSubscribersWorkFlowForConnectionEvent();
            //Subscribe to callback message that will be send from service
            NotificationMessageEvent.Instance.Subscribe(PublishedMessageAction);
        }
        string publishedMessage;
        public string PublishedMessage
        {
            get
            {
                return publishedMessage;
            }
            set
            {
                if (value == publishedMessage)
                    return;

                publishedMessage = value;
                RaisePropertyChanged("PublishedMessage");
                
              
            }
        }
        private void PublishedMessageAction(string message)
        {
            PublishedMessage = message;
        }

    }
}
