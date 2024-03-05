using AuctionApp.Service.Core.Models.DTO;
using System.Diagnostics;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        // класс для отправки запросов в сервис авторизации
        internal static class AuthService
        {
            private const string addressController = "api/Auth";

            public static List<string>? namesProducts = null;

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

                    (var userId, var _namesProducts) = ConvertResponse(response);

                    if (namesProducts != null)
                        namesProducts = _namesProducts;

                    return new ResultModel<string>()
                    {
                        Value = userId,
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

            private static (string, List<string>?) ConvertResponse(string response)
            {
                var indexStart = response.IndexOf('|');

                if (indexStart == -1)
                    return (response, null);

                var userId = response.Substring(0, indexStart);

                var arrayNameProduct = response.Substring(indexStart + 1).Split('|');

                return (userId, arrayNameProduct.ToList());
            }
        }
    }
}
