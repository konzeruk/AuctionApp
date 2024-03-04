using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
namespace AuctionApp.Forms
{
    public partial class BargainingForm : Form
    {
        private int userId,
            categoryId;
        private Dictionary<ProductModel, int> products;

        public BargainingForm(int userId, int categoryId, List<ProductModelResponse> productModels)
        {
            InitializeComponent();

            this.userId = userId;

            this.categoryId = categoryId;

            InitializeDataGridViewProducts(productModels);
        }

        private void InitializeDataGridViewProducts(List<ProductModelResponse> productModels)
        {
            if (dataGridViewProducts.Rows.Count > 0)
                ClearDataGridViewProducts();

            products = new();

            var row = 0;

            foreach (var productModel in productModels)
            {
                dataGridViewProducts.Rows.Add(productModel.Name, productModel.Price, productModel.DateEnd);

                products.Add(new ProductModel()
                {
                    Name = productModel.Name,
                    Price = productModel.Price,
                    DateEnd = productModel.DateEnd
                }, productModel.Id);

                ++row;
            }
        }

        private void ClearDataGridViewProducts()
        {
            dataGridViewProducts.Rows.Clear();
            dataGridViewProducts.Refresh();
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewProducts.Columns.Count - 1)
            {
                var indexRows = e.RowIndex;

                var price = Convert.ToDecimal(dataGridViewProducts.Rows[indexRows].Cells["ColumnPrice"].Value);

                var bidForm = new BidForm(price);

                bidForm.ShowDialog();

                var newPrice = bidForm.newPrice;

                if (newPrice != -1)
                    UpdataPriceProduct((double)newPrice, new ProductModel()
                    {
                        Name = dataGridViewProducts.Rows[indexRows].Cells["ColumnName"].Value.ToString()!,
                        DateEnd = Convert.ToDateTime(dataGridViewProducts.Rows[indexRows].Cells["ColumnDateEnd"].Value),
                        Price = (double)price
                    });
            }
        }

        private void UpdataPriceProduct(double newPrice, ProductModel productModel)
        {
            var productId = products[productModel];

            var result = Task.Run(async () => await Services.AuctionApp.StorageProduct.UpdataPriceProductAsync(productId, newPrice)).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }

            NewBid(new BargainingModel()
            {
                Price = newPrice,
                ProductId = productId,
                UserId = userId
            });

            UpdataProduct();
        }

        private void NewBid(BargainingModel bargainingModel)
        {
            var result = Task.Run(async () => await Services.AuctionApp.BargainingService.NewBidAsync(bargainingModel)).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }
        }

        private void UpdataProduct()
        {
            var result = Task.Run(async () => await Services.AuctionApp.StorageProduct.GetAllProductAsync(categoryId)).Result;

            if (result.Status != StatusResult.OK)
            {
                MessageBox.Show(result.Status);
                return;
            }

            InitializeDataGridViewProducts(result.Value);
        }

        private void bBack_Click(object sender, EventArgs e) =>
            Close();
    }
}
