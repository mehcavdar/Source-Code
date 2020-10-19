using System.Windows.Forms;

namespace CodeProjectWin
{
    public partial class MainForm
    {
        #region fields

        private ViewModel _viewModel;

        #endregion

        #region CTor

        public MainForm()
        {
          InitializeComponent();
            InitialControlHandlers();
        }

        #endregion

        #region Methods


        //Defining all Control handler methods
        //
        private void InitialControlHandlers()
        {
            _viewModel = new ViewModel();

            var listForm = new ListForm
            {
                ViewModel = _viewModel
            };

            //Defines the listForm as an owned form
            AddOwnedForm(listForm);  

            //Defines: if ListForm closes, the MainForm will close too
            listForm.FormClosing += (sender, e) =>
            {
                listForm.Dispose();
                Close();
            };

           
            //If the end user press Enter key, it will be like he/she clicked on Add button. 
            NameForAddingStart.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                    AddToList();
            };

            NameForAddingStop.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                    AddToList();
            };
            trackBar1.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)13)
                    AddToList();
            };

            Add.Click += (sender, e) => AddToList();

            Add.Tag = _viewModel.AddToListCommand;

            NameForAddingStart.Tag = _viewModel.HostChangedCommand;
            NameForAddingStop.Tag = _viewModel.Host1ChangedCommand;
            trackBar1.Tag = _viewModel.TrackScrollCommand;

            NameForAddingStart.DataBindings.Add(new Binding("Text", _viewModel, "Host"));
            NameForAddingStop.DataBindings.Add(new Binding("Text", _viewModel, "HostEnd"));
            trackBar1.DataBindings.Add(new Binding("Value", _viewModel, "LoadBalance"));
          
            listForm.Show();
        }

        private void AddToList()
        {

            _viewModel.Execute(Add.Tag, null);
            NameForAddingStart.Text = string.Empty;
            NameForAddingStop.Text = string.Empty;
            trackBar1.Value = 0;
            NameForAddingStart.Focus();
        }

        #endregion

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // MainForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(363, 190);
        //    this.Name = "MainForm";
        //    this.ResumeLayout(false);

        //}
    }
}
