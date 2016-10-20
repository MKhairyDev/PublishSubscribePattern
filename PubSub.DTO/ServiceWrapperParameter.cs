using System;
using System.ServiceModel;
namespace PubSub.DTO
{
    /// <summary>
    /// Encapsulate all properities required to create service channel
    /// </summary>
    public class ServiceWrapperParameter
    {
        public Uri ServiceUrl { get; set; }

        public InstanceContext InstanceContext { get; set; }


    }
}
