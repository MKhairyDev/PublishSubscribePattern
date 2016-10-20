using PubSub.DTO;
using System.Collections.Generic;

namespace PubSub.Contracts
{
    public interface ISubscribersManagement
    {
        bool AddSubscriber(ConnectedChannelInfo subscriberInformation);

        bool RemoveSubscriber(ConnectedChannelInfo subscriberInformation);

        IPubSubClientCallback GetSpesificSubscriberChannel(ConnectedChannelInfo subscriberInformation);

        List<IPubSubClientCallback> GetAllSubscribersChannels();
    }
}
