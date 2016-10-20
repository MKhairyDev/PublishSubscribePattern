using PubSub.DTO;
using PubSub.ImplementEventAggregator;
using PubSub.UtilitiesBase;
using System.ServiceModel;

namespace PubSub.Publisher.Model
{
    public class PublishStoreInfoModel
    {
        ServiceConnectionInitialization serviceConnectionInitialization;
        public void SubscribeToPublishEvent()
        {
            PublishDataEvent.Instance.Subscribe(PublishStoreDataAction);
        }
        private void PublishStoreDataAction(StoreDetails storeDetails)
        {
            Initialization();

            PublishToService(storeDetails);
        }
        public PublishStoreInfoModel()
        {
            Initialization();
        }
        private void Initialization()
        {

            PubSubClientCallback _clientCallback = new PubSubClientCallback();

            var instanceContext = new InstanceContext(_clientCallback);
            serviceConnectionInitialization = new ServiceConnectionInitialization(instanceContext);
        }
        private void PublishToService(StoreDetails storeDetails)
        {

            serviceConnectionInitialization.PublishToService(storeDetails);

        }
    }
}
