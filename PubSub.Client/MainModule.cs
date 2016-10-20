using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using PubSub.Client.View;

namespace PubSub.Client
{
    internal class MainModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("NotificationMsgRegion", typeof (ShowPublishedMessageUC));
           
        }
    }
}