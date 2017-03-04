using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConventer
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.CalculateCurrency();
        }

        private void CalculateCurrency()
        {
            var bulgarianCurrency = decimal.Parse(this.numericUpDown.Text);
            var targetCurrency = this.comboBoxCurrency.Text;
            var convertedAmount = 0.0m;
            if(targetCurrency == "EUR")
            {
                convertedAmount = bulgarianCurrency / 1.95583m;
            }
            else if(targetCurrency  == "USD")
            {
                convertedAmount = bulgarianCurrency / 1.80810m;
            }
            else
            {
                convertedAmount = bulgarianCurrency / 2.54990m;
            }
            var finalResult = Math.Round(convertedAmount, 3).ToString();
            this.resultLabel.Text = bulgarianCurrency + " лв. =" + finalResult + " " + targetCurrency;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Converter_Load(object sender, EventArgs e)
        {
            this.comboBoxCurrency.Text = "EUR";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalculateCurrency();
        }

        private void onClick(object sender, EventArgs e)
        {
            this.CalculateCurrency();
        }
    }
}
