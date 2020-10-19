using System;
using System.Windows.Forms;

namespace CodeProjectWin
{
    public partial class ListForm
    {
        #region CTor

        public ListForm()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        #endregion

        #region Properties

        public ViewModel ViewModel { get; set; }

        #endregion

        #region Methods

        private void InitializeEventHandlers()
        {
            Load += (sender, e) =>
            {
                var binding = new BindingSource
                {
                    DataSource = ViewModel.NameList
                };

                DataGridView.DataSource = binding;
                ViewModel.PropertyChanged += (o, eventArg) => BindDataGridView();
            };
        }

        private void BindDataGridView()
        {
            var binding = new BindingSource
            {
                DataSource = ViewModel.NameList
            };

            if (DataGridView.InvokeRequired){

                DataGridView.Invoke(new Action(() => DataGridView.DataSource = binding));
            }
            else
            {
                DataGridView.DataSource = binding;


            }


        }

       

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // ListForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(406, 301);
        //    this.Name = "ListForm";
        //    this.ResumeLayout(false);

        //}

        #endregion

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // ListForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(392, 256);
        //    this.Name = "ListForm";
        //    this.ResumeLayout(false);

        //}
    }
}
