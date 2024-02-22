using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AuctionApp.Service.Core.Models.DTO.Response
{
    public class AuthModelResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
