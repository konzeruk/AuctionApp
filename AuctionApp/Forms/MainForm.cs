using AuctionApp.Service.Core.Models.DTO;

namespace AuctionApp.Forms
{
    public partial class MainForm : Form
    {
        private string? userId;
        private Dictionary<string, int> categorys;

        //TODO: оттестить функционнал выигрыша и комменты добавить по всем фронтам

        public MainForm()
        {
            Visible = false;

            userId = Authorization();

            if (userId == null)
                Exit();

            InitializeComponent();

            InitializeListBoxCategory();

            NotificationsWin();

            Visible = true;

        }

        private string? Authorization()
        {
            var authForm = new AuthForm();
            authForm.ShowDialog();

            return authForm.userId;
        }

        private void NotificationsWin()
        {
            var namesProducts = Services.AuctionApp.AuthService.namesProducts;

            if(namesProducts != null)
                foreach (var name in namesProducts)
                    MessageBox.Show($"Ваша ставка на товар {name} победила");
        }

        private void InitializeListBoxCategory()
        {
            var result = Task.Run(Services.AuctionApp.StorageProduct.GetAllCategoryAsync).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }

            categorys = new();

            var categoryModels = result.Value;

            foreach (var categoryModel in categoryModels)
            {
                listBoxCategory.Items.Add(categoryModel.Name);

                categorys.Add(categoryModel.Name, categoryModel.Id);
            }
        }

        private void listBoxCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = listBoxCategory.SelectedIndex;

            var categoryId = categorys[listBoxCategory.Items[index].ToString()];

            var result = Task.Run(async () => await Services.AuctionApp.StorageProduct.GetAllProductAsync(categoryId)).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }

            Visible = false;

            var bidForm = new BargainingForm(Convert.ToInt32(userId), categoryId, result.Value);
            bidForm.ShowDialog();

            Visible = true;
        }


        private void Exit() =>
            Application.Exit();

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm(categorys.Keys.ToArray());
            addProductForm.ShowDialog();

            var nameCategory = addProductForm.nameCategory;

            var productModel = addProductForm.productModel;

            if(nameCategory != null && productModel != null)
                AddNewProduct(categorys[nameCategory], productModel);
        }

        private void AddNewProduct(int categoryId, ProductModel productModel)
        {
            var result = Task.Run(async () => await Services.AuctionApp.StorageProduct.AddProductAsync(categoryId, productModel)).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }

            MessageBox.Show("Товар добавлен");
        }
    }
}
