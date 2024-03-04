using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionApp.Forms
{
    public partial class BidForm : Form
    {
        public decimal newPrice = -1;

        public BidForm(decimal minimalPrice)
        {
            InitializeComponent();

            InitializeNumericUpDownPrice(minimalPrice);
        }

        private void InitializeNumericUpDownPrice(decimal minimalPrice)
        {
            numericUpDownPrice.Minimum = minimalPrice;
            numericUpDownPrice.Maximum = int.MaxValue;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            var _newPrice = numericUpDownPrice.Value;
            if (CheckNewPrice(_newPrice))
            {
                newPrice = Convert.ToInt32(numericUpDownPrice.Value);
                Exit();
            }
            else
                MessageBox.Show("Ставка не сделана");
        }

        private bool CheckNewPrice(decimal price) =>
            (price <= numericUpDownPrice.Minimum) ? false : true;

        private void bCancel_Click(object sender, EventArgs e) =>
            Exit();

        private void Exit() =>
            Close();
    }
}
