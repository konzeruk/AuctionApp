namespace AuctionApp.Service.Core.Exceptions
{
    public class ApiError
    {
        public int Code { get; set; }

        public string Message { get; set; } = default!;
    }
}
