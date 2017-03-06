using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointAndRectangleGA
{
    public partial class FormPointAndRectangle : Form
    {
        public FormPointAndRectangle()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownX1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownY1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void numericUpDownX2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownY2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownX_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownY_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormPointAndRectangle_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void FormPointAndRectangle_Resize(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
