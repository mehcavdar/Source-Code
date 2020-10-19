using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeProjectWin
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();

            DataAccess dataAccess = new DataAccess();
        }
    }
}
