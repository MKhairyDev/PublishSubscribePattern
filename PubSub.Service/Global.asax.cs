using Autofac;
using Autofac.Integration.Wcf;
using PubSub.Contracts;
using PupSub.Service.ManageSubscribers;
using System;

namespace PubSub.Service
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // build and set container in application start 
            var builder = new ContainerBuilder();

            // Register your service implementations.
            builder.RegisterType<PubSubService>().SingleInstance();
            builder.RegisterType<SubscribersManagement>().As<ISubscribersManagement>();
            // Set the dependency resolver.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }


    }
}