namespace AuctionApp.Service.Core.Models.DTO
{
    public sealed class RequestModel
    {
        public string BaseAddress { get; set; }
        public string Request {  get; set; }
        public HttpMethod _HttpMethod {  get; set; }

    }
}
