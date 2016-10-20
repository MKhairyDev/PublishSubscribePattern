using System.ServiceModel;

namespace PubSub.Contracts
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPubSubClientCallback))]
    public interface IPubSubContract:ISubscriber,IPublisher
    {

    }
}
