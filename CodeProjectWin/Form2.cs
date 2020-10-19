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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.AddOwnedForm(loginForm);

            while (!loginForm.IsAuthenticated)
            {              

                if (loginForm.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Close();
                    break;
                }
            }

            //Show username



        }

        private void ChangeValue(DateTime value)
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
