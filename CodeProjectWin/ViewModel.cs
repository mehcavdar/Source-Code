using System.ComponentModel;
using System.Collections.ObjectModel;
using CodeProjectWin;

namespace CodeProjectWin
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Properties

        public string Host { get; set; }


        public string HostEnd { get; set; }

        public int LoadBalance { get; set; }

        private ICommand _addToListCommand;
        public ICommand AddToListCommand
        {
            get
            {
                return _addToListCommand ?? (_addToListCommand = new AddToList(this));
            }
        }

        private ICommand _hostChangedCommand;
        public ICommand HostChangedCommand
        {
            get
            {
                return _hostChangedCommand ?? (_hostChangedCommand = new TextChanged(this));
            }
        }

        private ICommand _host1ChangedCommand;
        public ICommand Host1ChangedCommand
        {
            get
            {
                return _host1ChangedCommand ?? (_host1ChangedCommand = new TextChanged(this));
            }
        }
        private ICommand _trackScrollCommand;
        public ICommand TrackScrollCommand
        {
            get
            {
                return _trackScrollCommand ?? (_trackScrollCommand = new ScrollChanged(this));
            }
        }

        private ObservableCollection<HostValue> _nameList;
        public ObservableCollection<HostValue> NameList
        {
            get
            {
                return _nameList;
            }

            set
            {
                _nameList = value;

                _nameList.CollectionChanged += MyPropertyCollectionChanged;
            }
        }

        #endregion

        #region CTor

        public ViewModel()
        {
            var model = new Model();
            model.PropertyChanged += ModelPropertyChanged;
            NameList = model.List;
        }

        #endregion

        #region PropeetyChanged Handlers

        void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NameList = (ObservableCollection<HostValue>)sender; //For Get any new entity Changed 
        }

        void MyPropertyCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            {
                NotifyPropertyChanged("NameList");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        public void Execute(object sender, object parameter)
        {
            ((ICommand)sender).Execute(parameter);
        }

        #endregion
    }


}

#region I Classes

public class AddToList : ICommand
{
    #region CTor

    public AddToList(ViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    #endregion

    #region Properties

    public ViewModel ViewModel { get; set; }

    #endregion

    #region ICommand Members

    public void Execute(object sender)
    {
        if (string.IsNullOrEmpty(ViewModel.Host) || string.IsNullOrEmpty(ViewModel.HostEnd))
            return;
        if (string.IsNullOrEmpty(ViewModel.Host.Trim()) || string.IsNullOrEmpty(ViewModel.HostEnd.Trim()))
            return;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(ViewModel.Host).Append("-").Append(ViewModel.HostEnd).Append("-").Append(ViewModel.LoadBalance);

        ViewModel.NameList.Add(new HostValue(sb.ToString(),"","",false,false));
    }

    #endregion
}

public class TextChanged : ICommand
{
    #region CTor

    public TextChanged(ViewModel viewModel)
    {
        DataAccess = viewModel;
    }

    #endregion

    #region Properties

    public ViewModel DataAccess { get; set; }

    #endregion

    #region ICommand Members

    public void Execute(object sender)
    {
        DataAccess.Host = sender.ToString();
    }

    #endregion
}

public class ScrollChanged : ICommand
{
    #region CTor

    public ScrollChanged(ViewModel viewModel)
    {
        DataAccess = viewModel;
    }

    #endregion

    #region Properties

    public ViewModel DataAccess { get; set; }

    #endregion

    #region ICommand Members

    public void Execute(object sender)
    {
        DataAccess.Host = sender.ToString();
    }

    #endregion
}



#endregion



#region StringValue Class

public class HostValue
{


    public bool IsHost { get; set; }
    public string Host { get; set; }

    public string PortNum { get; set; }
    public bool IsPortOpen { get; set; }

    public string Value { get; set; }
    public HostValue(string value,string host,string portNum,bool isPort,bool isHost)
    {
        Value = value;
        Host = host;
        PortNum = portNum;
        IsPortOpen = isPort;
        IsHost = IsHost;

    }


   
}

#endregion
