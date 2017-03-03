using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchTheButtonReal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonMouseEnter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Evala 100 to4ki priqtel");
        }

        private void ButtonMouseEnter_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ButtonMouseEnter_MouseHover(object sender, EventArgs e)
        {
            Random rand = new Random();
            var maxWidth = this.ClientSize.Width - ButtonMouseEnter.ClientSize.Width;
            var maxHeight = this.ClientSize.Height - ButtonMouseEnter.ClientSize.Height;
            this.ButtonMouseEnter.Location = new Point(rand.Next(maxWidth), rand.Next(maxHeight));
        }
    }
}
