using PubSub.Contracts;
using PubSub.DTO;
using System;
using System.Configuration;
using System.ServiceModel;


namespace PubSub.UtilitiesBase
{
    public class ServiceConnectionInitialization
    {

        string PubSubServiceUri;
        private static UtilitiesBaseServiceWrapper<IPubSubContract> _serviceWrapper;
        public ServiceConnectionInitialization(InstanceContext instanceContext)
        {
            Initialization(instanceContext);

        }
        private void Initialization(InstanceContext instanceContext)
        {


            PubSubServiceUri = ConfigurationManager.AppSettings["PubSubServiceUri"];
            var serviceWrapperParameter = new ServiceWrapperParameter()
            {
                ServiceUrl = new Uri(PubSubServiceUri),

                InstanceContext = instanceContext,

            };
            _serviceWrapper = GetServiceChannel(serviceWrapperParameter);
        }

        private static UtilitiesBaseServiceWrapper<IPubSubContract> GetServiceChannel(ServiceWrapperParameter wrapperParameter)
        {

            if (wrapperParameter != null)
                return new UtilitiesBaseServiceWrapper<IPubSubContract>(wrapperParameter.ServiceUrl, true, wrapperParameter.InstanceContext);
            return null;

        }
        public void PublishToService(StoreDetails storeDetails)
        {

            _serviceWrapper.Channel.PublishNewStore(storeDetails);

        }
        public void SubscribeToService(ConnectedChannelInfo SubscriberInformation)
        {

            _serviceWrapper.Channel.Subscribe(SubscriberInformation);

        }
    }
}
