
using PubSub.DTO;
using PubSub.ImplementEventAggregator;
using PubSub.Publisher.Model;

namespace PubSub.Client.ViewModel
{
   public class InitializePublisherSubscribersWorkFlow
    {
        public static void SetPublisherSubscribersWorkFlowForConnectionEvent(StoreDetails storeDetails)
        {
            PublishStoreInfoModel publishStoreInfoModel = new PublishStoreInfoModel();
            publishStoreInfoModel.SubscribeToPublishEvent();

            //Publish Event to model component to start a connection with the service
            PublishDataEvent.Instance.Publish(storeDetails);

        
        }
    }
}
