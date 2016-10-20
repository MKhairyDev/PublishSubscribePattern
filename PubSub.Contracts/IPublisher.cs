using PubSub.DTO;
using System.ServiceModel;

namespace PubSub.Contracts
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPublisher
    {

        [OperationContract(IsOneWay = true)]
        void PublishNewStore(StoreDetails storeDetails);
    }
}
