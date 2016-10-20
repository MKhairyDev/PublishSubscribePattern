using PubSub.Contracts;
using PubSub.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace PupSub.Service.ManageSubscribers
{
    public class SubscribersManagement : ISubscribersManagement
    {
        private static readonly Dictionary<ConnectedChannelInfo, IPubSubClientCallback> DicClients =
    new Dictionary<ConnectedChannelInfo, IPubSubClientCallback>();
        private static IPubSubClientCallback CallbackChannel
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IPubSubClientCallback>();

            }
        }

        public bool AddSubscriber(ConnectedChannelInfo subscriberInformation)
        {
            if (subscriberInformation == null)
                throw new ArgumentNullException();
           return SaveCurrentChannel(subscriberInformation);

        }

        public bool RemoveSubscriber(ConnectedChannelInfo subscriberInformation)
        {
            if (subscriberInformation == null)
                throw new ArgumentNullException();
           return RemoveCurrentChannel(subscriberInformation);
        }

        public IPubSubClientCallback GetSpesificSubscriberChannel(ConnectedChannelInfo subscriberInformation)
        {
            if (subscriberInformation == null)
                throw new ArgumentNullException();
            ConnectedChannelInfo client = DicClients.Keys.FirstOrDefault(x => x.ChannelId == subscriberInformation.ChannelId);
            if (client != null)
            {
               return DicClients[client];
            }
            return null;
        }

        public List<IPubSubClientCallback> GetAllSubscribersChannels()
        {
          return  DicClients.Values.ToList();
        }
        private static bool SaveCurrentChannel(ConnectedChannelInfo clientInformation)
        {
            try
            {

                if (clientInformation == null)
                    throw new ArgumentNullException();
                ConnectedChannelInfo client = GetClientByChannelId(clientInformation);
                if (client != null)
                {
                    DicClients.Remove(client);
                }

                DicClients.Add(clientInformation, CallbackChannel);

                return true;
            }
            catch (ArgumentNullException)
            {
                return false; 
            }
            catch(ArgumentException)
            {
                return false;
            }
          

        }

        private static ConnectedChannelInfo GetClientByChannelId(ConnectedChannelInfo subscriberInformation)
        {
            return DicClients.Keys.FirstOrDefault(x => x.ChannelId == subscriberInformation.ChannelId);
        }

        private static bool RemoveCurrentChannel(ConnectedChannelInfo clientInformation)
        {
            if (clientInformation == null)
                throw new ArgumentNullException();
            try
            {
                ConnectedChannelInfo client = GetClientByChannelId(clientInformation);
                if (client != null)
                {
                    DicClients.Remove(client);
                }
                return true;
              
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
