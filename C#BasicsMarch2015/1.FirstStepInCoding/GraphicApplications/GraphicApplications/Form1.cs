using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicApplications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sum_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = double.Parse(this.num1.Text);
                var num2 = double.Parse(this.num2.Text);
                var result = num1 + num2;

                this.result.Text = result.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Invalid data");
            }            
        }
    }
}
