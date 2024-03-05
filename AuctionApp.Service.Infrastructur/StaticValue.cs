using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;

namespace AuctionApp.Service.Infrastructur
{
    public static class StaticValue
    {
        public static List<BargainingModelResponse> WinBid { get; set; } = new();

        public static List<BargainingModelResponse>? GetWinBidByUserId(int userId)
        {
            if(WinBid.Count == 0)
                return null;

            return WinBid
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public static void DeleteWinBids(List<BargainingModelResponse> bargainingModels)
        {
            foreach(var model in bargainingModels)
                WinBid.Remove(model);
        }
    }
}
