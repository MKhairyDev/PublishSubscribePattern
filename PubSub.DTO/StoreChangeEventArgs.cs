using System;

namespace PubSub.DTO
{
    public class StoreChangeEventArgs: EventArgs
    {
        private readonly StoreDetails storeDetails;

        public StoreChangeEventArgs(StoreDetails storeDetails)
        {
            this.storeDetails = storeDetails;
        }

        public StoreDetails StoreDetails
        {
            get { return storeDetails; }
        }
    }
}
