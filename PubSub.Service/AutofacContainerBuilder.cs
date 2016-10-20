
using Autofac;
using PubSub.Contracts;
using PupSub.Service.ManageSubscribers;

namespace PubSub.Service
{
/// <summary>
/// Class to build Autofac IOC container.
/// </summary>
public static class AutofacContainerBuilder
{
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        /// <returns></returns>
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register types
            builder.RegisterType<SubscribersManagement>().As<ISubscribersManagement>().SingleInstance();
            builder.RegisterType<PubSubService>().SingleInstance();

            // build container
            return builder.Build();
        }
}
}