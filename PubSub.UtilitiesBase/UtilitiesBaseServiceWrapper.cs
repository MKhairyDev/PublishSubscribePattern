using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;

namespace PubSub.UtilitiesBase
{
    public class UtilitiesBaseServiceWrapper<TIService> : IDisposable where TIService : class
    {
        private ChannelFactory<TIService> _factory;
        private TIService _channel;

        private readonly Binding _binding;
        private readonly EndpointAddress _endpoint;

        private readonly object _lockObject = new object();
        private bool _disposed;
        private bool _duplex;
        private InstanceContext _instanceContext;

        public UtilitiesBaseServiceWrapper(Uri configName, bool duplex = false, InstanceContext instanceContext = null)
        {
            _instanceContext = instanceContext;

            _duplex = duplex;
            if (_duplex)
            {
                _binding = new NetTcpBinding
                {

                    CloseTimeout = new TimeSpan(0, 5, 0),
                    OpenTimeout = new TimeSpan(0, 5, 0),
                    ReceiveTimeout = TimeSpan.MaxValue,
                    SendTimeout = new TimeSpan(0, 5, 0),
                    MaxBufferPoolSize = 67108864,
                    MaxReceivedMessageSize = 67108864,
                    MaxBufferSize = 67108864,
                    TransferMode = TransferMode.Buffered,
                    ReaderQuotas = new XmlDictionaryReaderQuotas
                    {

                        MaxStringContentLength = 67108864,
                        MaxArrayLength = 67108864,
                        MaxBytesPerRead = 67108864,

                    },

                    Security = new NetTcpSecurity()
                    {
                        Mode = SecurityMode.None,
                    }
                                   ,
                    ReliableSession = new OptionalReliableSession { Enabled = true, InactivityTimeout = TimeSpan.MaxValue }
                    ,


                };

            }
            else
            {

                _binding = new WSHttpBinding
                {
                    CloseTimeout = new TimeSpan(0, 0, 10, 0),
                    OpenTimeout = new TimeSpan(0, 0, 10, 0),
                    ReceiveTimeout = TimeSpan.MaxValue,
                    SendTimeout = TimeSpan.MaxValue,
                    MaxBufferPoolSize = 999999999,
                    MaxReceivedMessageSize = 999999999,
                    ReaderQuotas = new XmlDictionaryReaderQuotas
                    {
                        MaxDepth = 999999999,
                        MaxStringContentLength = 999999999,
                        MaxArrayLength = 999999999,
                        MaxBytesPerRead = 999999999,
                        MaxNameTableCharCount = 999999999
                    }
                    ,
                    ReliableSession = new OptionalReliableSession
                    {
                        Enabled = true,
                        InactivityTimeout = TimeSpan.MaxValue
                    }


                };

                ((WSHttpBinding)_binding).Security = new WSHttpSecurity
                {
                    Mode = SecurityMode.Transport,
                    Transport = new HttpTransportSecurity
                    {
                        ClientCredentialType = HttpClientCredentialType. None

                    },

                };

            }
            _endpoint = new EndpointAddress(configName);


            _disposed = false;
        }

        public TIService Channel
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Resource ServiceWrapper<" + typeof(TIService) + "> has been disposed");
                }

                lock (_lockObject)
                {
                    if (_factory == null)
                    {

                        _factory = _duplex ? new DuplexChannelFactory<TIService>(_instanceContext, _binding, _endpoint) : new ChannelFactory<TIService>(_binding, _endpoint);

                        _channel = _factory.CreateChannel();

                    }
                }
                return _channel;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (!disposing)
                return;
            lock (_lockObject)
            {
                if (_channel != null)
                {
                    ((IClientChannel)_channel).Close();
                }
                if (_factory != null)
                {
                    _factory.Close();
                }
            }

            _channel = null;
            _factory = null;
            _disposed = true;
        }
    }
}
