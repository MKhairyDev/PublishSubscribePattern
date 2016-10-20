using PubSub.Client.Model;
using PubSub.ImplementEventAggregator;

namespace PubSub.Client.ViewModel
{
    public class InitializePublisherSubscribersWorkFlow
    {
        public static void SetPublisherSubscribersWorkFlowForConnectionEvent()
        {
            ShowPublishedMessageModel showPublishedMessageModel = new ShowPublishedMessageModel();
            showPublishedMessageModel.SubscribeToConnectionEvent();

            //Publish Event to model component to start a connection with the service
            ManageConnectionEvent.Instance.Publish(true);

        
        }
    }
}
