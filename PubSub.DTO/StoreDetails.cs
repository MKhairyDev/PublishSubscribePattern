using System.Runtime.Serialization;

namespace PubSub.DTO
{
    [DataContract]
    public class StoreDetails
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }

    }
}
