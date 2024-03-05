namespace AuctionApp.Service.Core.Models.DTO
{
    public sealed class ResultModel<T>
    {
        public T? Value { get; set; }
        public string Status { get; set; }
    }
}
