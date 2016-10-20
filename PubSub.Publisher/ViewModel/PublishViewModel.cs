using PubSub.Client.ViewModel;
using PubSub.Publisher.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PubSub.Publisher
{
    public class PublishViewModel : INotifyPropertyChanged
    {
        private string storeName;
        private string storeAddress;
        public PublishViewModel()
        {
            _canExecute = true;
        }
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction()
        {
            var storeObj = new DTO.StoreDetails() { Name = storeName, Address = StoreAddress };
            InitializePublisherSubscribersWorkFlow.SetPublisherSubscribersWorkFlowForConnectionEvent(storeObj);//
        }
        public string StoreName
        {
            get
            {
                return storeName;
            }
            set
            {
                storeName = value;
                RaisePropertyChanged("StoreName");
            }
        }
    
        public string StoreAddress
        {
            get
            {
                return storeAddress;
            }
            set
            {
                storeAddress = value;
                RaisePropertyChanged("StoreName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }

}
