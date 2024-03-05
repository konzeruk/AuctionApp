using AuctionApp.Service.Core.Models.DTO;
using Azure;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        internal static class BargainingService
        {
            private const string addressController = "api/Bid";

            public static async Task<ResultModel<BargainingModel>> NewBidAsync(BargainingModel bargainingModel)
            {
                try
                {
                    var request = "newBid";

                    await httpClient._SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Post
                    }, bargainingModel);

                    return new ResultModel<BargainingModel>()
                    {
                        Value = null,
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<BargainingModel>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Не удалось добавить торг"
                    };
                }
            }
        }
    }
}
