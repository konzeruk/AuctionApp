using AuctionApp.Forms;
using AuctionApp.Service.Core.Models.DTO;
namespace AuctionApp
{
    public partial class AuthForm : Form
    {
        public string? userId = null;

        public AuthForm()
        {
            InitializeComponent();
        }

        private void bEntry_Click(object sender, EventArgs e)
        {
            if(!CheckNotEmptyTextBox())
            {
                labelError.Text = $"{StatusResult.ERROR}: Ћогин или пароль не введЄн";
                return;
            }

            if(labelError.Text.Length != 0)
                labelError.Text = string.Empty;

            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            var result = Task.Run(async () => await Services.AuctionApp.AuthService.GetUserIdAsync(new AuthModel()
            {
                Login = login,
                Password = password
            })).Result;

            if (result.Status != StatusResult.OK)
            {
                labelError.Text = result.Status;
                return;
            }

            userId = result.Value;

            Close();
        }

        private bool CheckNotEmptyTextBox() =>
            (textBoxLogin.Text.Length == 0 || textBoxPassword.Text.Length == 0)? false : true;
    }
}
