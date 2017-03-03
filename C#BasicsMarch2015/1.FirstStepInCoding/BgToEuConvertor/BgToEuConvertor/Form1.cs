using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BgToEuConvertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void input_ValueChanged(object sender, EventArgs e)
        {
            decimal money = decimal.Parse(this.input.Value.ToString());
            decimal euro = money * 0.5m;
            this.result.Text = euro.ToString() + " Euroes";
        }   
    }
}
