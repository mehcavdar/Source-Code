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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HostApplication h = new HostApplication("127.0.0.1", 1, 65535);
            //h.Scan();


            //Banka banka = new Banka();
            //banka.PropertyChanged += Banka_PropertyChanged;
            //banka.Para += 100;

            //Console.Read();


        }
        private static void Banka_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
          DialogResult dr= MessageBox.Show("Para eklendi","ef",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
        }
    }
}
