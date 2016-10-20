using PubSub.DTO;
using PubSub.ImplementEventAggregator;
using PubSub.UtilitiesBase;
using System;
using System.Configuration;
using System.ServiceModel;

namespace PubSub.Client.Model
{
    public class ShowPublishedMessageModel
    {
        string publishedMessage;
        ServiceConnectionInitialization serviceConnectionInitialization;
        private int? channelId;

        public int? ChannelId
        {
            get
            {
                if (channelId == null)
                {
                    var ChannelRes = ConfigurationManager.AppSettings["ChannelId"];
                    if (!string.IsNullOrEmpty(ChannelRes))
                    {
                        return int.Parse(ChannelRes);
                    }
                }
                return channelId;
            }
          
        }
        public  void SubscribeToConnectionEvent()
        {
            ManageConnectionEvent.Instance.Subscribe(StartServiceConnection);
        }
        private  void StartServiceConnection(bool isConnectProcess)
        {
            Initialization();
            if(isConnectProcess)
            SubscribeToService();
        }
        private void Initialization()
        {

            PubSubClientCallback _clientCallback = new PubSubClientCallback();

            var InstanceContext = new InstanceContext(_clientCallback);
            serviceConnectionInitialization = new ServiceConnectionInitialization(InstanceContext);
        }
        private void SubscribeToService()
        {

            if (ChannelId != null)
            {

                var clientInfo = new ConnectedChannelInfo { ChannelId = ChannelId.Value, ChannelName = "Test PC " + ChannelId.ToString() };
                serviceConnectionInitialization.SubscribeToService(clientInfo);
            }
        }
        public string PublishedMessage
        {
            get
            {
                return publishedMessage;
            }
            set
            {
                publishedMessage = value;
                NotificationMessageEvent.Instance.Publish(publishedMessage);
            }
        }
    }
}
