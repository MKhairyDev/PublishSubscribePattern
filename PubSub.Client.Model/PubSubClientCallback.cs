using PubSub.Contracts;
using PubSub.DTO;
using System.ServiceModel;
using PubSub.Client.Model;

namespace PubSub.Client
{
    [CallbackBehaviorAttribute(UseSynchronizationContext = false)]
    public class PubSubClientCallback : IPubSubClientCallback
    {
        ShowPublishedMessageModel showPublishedMessageModel;
        public PubSubClientCallback()
        {
            showPublishedMessageModel = new ShowPublishedMessageModel();
        }
        public void NewStoreCreated(StoreDetails storeDetails)
        {
            showPublishedMessageModel.PublishedMessage = storeDetails.Name + " Store Is Created in below location \n " + storeDetails.Address;

             


        }
    }
}
