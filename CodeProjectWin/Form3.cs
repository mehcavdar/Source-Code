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
    public partial class LoginForm : Form
    {

        public bool IsAuthenticated { get; set; }

        public string UserName { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            IsAuthenticated = false;

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }


}
public class ProductInfo
{    
    public ProductInfo(string name, string location, double price)
    {
        Name = name;
        Location = location;
        Price = price;
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _location;
    public string Location
    {
        get { return _location; }
        set { _location = value; }
    }

    private double _price;
    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }    
}


