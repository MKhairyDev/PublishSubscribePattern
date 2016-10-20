using PubSub.Contracts;
using PubSub.DTO;
using System.ServiceModel;

namespace PubSub.Publisher
{
    [CallbackBehaviorAttribute(UseSynchronizationContext = false)]
    public class PubSubClientCallback : IPubSubClientCallback
    {
        public void NewStoreCreated(StoreDetails storeDetails)
        {
     
        }
    }
}
