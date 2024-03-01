using AuctionApp.Service.Core.Models.DTO;
using System.Diagnostics;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        internal static class AuthService
        {
            private const string addressController = "api/Auth";
            public static async Task<ResultModel<string>> GetUserIdAsync(AuthModel authModel)
            {
                try
                {
                    var response = await httpClient.SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = string.Empty,
                        _HttpMethod = HttpMethod.Get
                    }, authModel);

                    return new ResultModel<string>()
                    {
                        Value = response,
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<string>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Пароль или логин был введён не верно"
                    };
                }
            }
        }
    }
}
