using PubSub.DTO;
using System.ServiceModel;

namespace PubSub.Contracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ISubscriber
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        bool Subscribe(ConnectedChannelInfo connectedChannelInfo);
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        bool Unsubscribe(ConnectedChannelInfo connectedChannelInfo);
    
    }
}
