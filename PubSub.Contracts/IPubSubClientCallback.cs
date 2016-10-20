using PubSub.DTO;
using System.ServiceModel;

namespace PubSub.Contracts
{
    public interface IPubSubClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void NewStoreCreated(StoreDetails storeDetails);
    }
}
