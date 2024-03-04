using AuctionApp.Service.Core.Models.DTO;

namespace AuctionApp.Forms
{
    public partial class AddProductForm : Form
    {
        public string? nameCategory = null;

        public ProductModel? productModel = null;

        public AddProductForm(string[] categorys)
        {
            InitializeComponent();

            InitializeNumericUpDownPrice();

            InitializeDateTimePickerDateEnd();

            InitializeComboBoxCategory(categorys);
        }

        private void InitializeNumericUpDownPrice() =>
            numericUpDownPrice.Maximum = decimal.MaxValue;

        private void InitializeDateTimePickerDateEnd()
        {
            dateTimePickerDateEnd.MinDate = DateTime.Now;
            dateTimePickerDateEnd.CustomFormat = "yyyy-mm-dd hh:mm:ss";
        }

        private void InitializeComboBoxCategory(string[] categorys)
        {
            foreach (var category in categorys)
                comboBoxCategory.Items.Add(category);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxName())
                MessageBox.Show("Название товара не введено");

            if(!CheckNumericUpDownPrice())
                MessageBox.Show("Цена товара не может быть равна нулю");

            nameCategory = comboBoxCategory.Items[comboBoxCategory.SelectedIndex].ToString();

            productModel = new ProductModel()
            {
                Name = textBoxName.Text,
                Price = (double)numericUpDownPrice.Value,
                DateEnd = dateTimePickerDateEnd.Value
            };

            Exit();
        }

        private bool CheckTextBoxName()
        {
            var name = textBoxName.Text;

            if (string.IsNullOrEmpty(name))
                return false;

            return true;
        }

        private bool CheckNumericUpDownPrice()
        {
            var price = numericUpDownPrice.Value;

            if (price == 0)
                return false;

            return true;
        }

        private void bCancel_Click(object sender, EventArgs e) =>
            Exit();

        private void Exit() =>
            Close();
    }
}
