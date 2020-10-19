using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CodeProjectWin
{
    public class Model : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<HostValue> List { get; set; }

        #endregion

        #region Fields

        private readonly DataAccess _dal = new DataAccess();

        #endregion

        #region CTor

        public Model()
        {
            List = _dal.Select();

            _dal.DatabaseUpdated += UpdataFromDal;

            List.CollectionChanged += ListCollectionChanged;
        }

        #endregion

        #region Methods
        private void ListCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _dal.Update(List);
        }

        private void UpdataFromDal(ObservableCollection<HostValue> list)
        {
            List = list;

            List.CollectionChanged += ListCollectionChanged;
            if (PropertyChanged != null)
                PropertyChanged(List, null);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
