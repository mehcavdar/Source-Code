using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CodeProjectWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();




            DoMyMethod();
        }

        private void DoMyMethod()
        {
            List<string> People = new List<string>();
            List<string> temp = new List<string>();

            People.Add("Farah");
            People.Add("Mohammad");
            People.Add("Gholam Reza");
            People.Add("Bahram");
            People.Add("Mehrdad");
            People.Add("Zahra");
            People.Add("Jahangir");
            People.Add("Shahin");

            temp.Add("Shahin");

            People.Reverse(0, People.Count);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form()
                {
                    Text = "Hello"
                };
            this.Enabled = false;
            form.ShowDialog();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            Form form = new Form()
            {
                Text = "Goodby"
            };
            
            timer1.Stop();
            form.Show();


        }
 
    }
}
