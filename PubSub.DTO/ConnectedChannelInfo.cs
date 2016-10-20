using System.Runtime.Serialization;

namespace PubSub.DTO
{
    /// <summary>
    /// Encapsulate all data required for client to connect to webservice.
    /// </summary>
    [DataContract]
    public class ConnectedChannelInfo
    {
        /// <summary>
        /// Indicate to channel id that will connect to  service
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }
        /// <summary>
        /// Indicate to channel name that will connect to service
        /// </summary>
        [DataMember]
        public string ChannelName { get; set; }
    }
}
