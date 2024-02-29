namespace AuctionApp.Service.Core.Models.DTO
{
    public class RequestModel
    {
        public string Request {  get; set; }
        public string NameApi { get; set; }
        public HttpMethod _HttpMethod {  get; set; }
    }
}
