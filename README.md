# Publish/Subscribe Pattern
Design Patterns: List-Based Publish-Subscribe

One of the key aspects of a publisher/subscriber pattern is that there should be ultra-loose coupling between the publisher and the subscriber. Critically, the publisher should not know anything about the subscribers, including how many there are or where they live. 

The Publish-Subscribe pattern passes information to a collection of recipients who have subscribed to an information topic.
List-based publish-subscribe maintains a list of subscribers. When there is information to share, a copy is sent to each subscriber on 
the list. This sample demonstrates a dynamic list-based publish-subscribe pattern, where clients can subscribe or unsubscribe as often
as required.

This sample consists of a client, a service, and a publisher program. There can be more than one client and more than one
publisher program running. Clients subscribe to the service, receive notifications, and unsubscribe. Publisher programs send information
to the service to be shared with all current subscribers.

In this sample, the client and Publisher programs (.exe files) are visible on the desktop and are developed using WPF & MVVM & Prism &
Event Aggregator and the service is a WCF library (.dll) hosted in Internet Information Services (IIS).

The service uses duplex communication. The IPubSubContract service contract is paired up with an IPubSubClientCallback callback contract. The service implements subscribe and Unsubscribe service operations, which clients use to join or leave the list of subscribers . The service also implements the PublishNewStore service operation, which the Publisher program calls to provide the service with new information. The client program implements the NewStoreCreated service operation, which the service calls to notify all subscribers of a price change.

I'm using channel factory to construct the channel because I do not need to change channel factory code when there is a change in data contract, service contract and callback contract.  Here to use Channel Factory to construct channel between server and publisher/subscriber, all the contracts are kept in a separate DLL that is shared by server, publisher and Subscribe. 

Each client application is consist of two component :
-business aggregation and business logic (ex: “PubSub.Client.Model” & PubSub.Publisher.Model”)
- View and View Model (ex: “PubSub.Client” & PubSub.Publisher)
 The client and Publisher programs are WPF Application developed by:
  - WPF
  -  MVVM 
  - Prism 
  - Prism Event Aggregator
