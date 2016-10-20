using PubSub.Contracts;
using PubSub.DTO;
using System.ServiceModel;

namespace PubSub.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    public class PubSubService : IPubSubContract
    {
        ISubscribersManagement subscribersManagement;
        public PubSubService(ISubscribersManagement subscribersManagement)
        {
            this.subscribersManagement = subscribersManagement;
        }

        public bool Subscribe(ConnectedChannelInfo connectedChannelInfo)
        {
            return subscribersManagement.AddSubscriber(connectedChannelInfo);
        }

        public bool Unsubscribe(ConnectedChannelInfo connectedChannelInfo)
        {
            return subscribersManagement.RemoveSubscriber(connectedChannelInfo);
        }
        public void PublishNewStore(StoreDetails storeDetails)
        {
        var allChannels=    subscribersManagement.GetAllSubscribersChannels();
            for (int i = 0; i < allChannels.Count; i++)
            {
                allChannels[i].NewStoreCreated(storeDetails);
            }
        }



    }
}
