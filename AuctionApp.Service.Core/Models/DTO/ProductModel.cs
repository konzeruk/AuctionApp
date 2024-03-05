using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public sealed class ProductModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("dateEnd")]
        public DateTime DateEnd { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) 
                return false;
            
            var item = obj as ProductModel;

            if(Name != item.Name || Price != item.Price || DateEnd != item.DateEnd)
                return false;

            return true;
        }
        public override int GetHashCode() => 
            HashCode.Combine(Name, Price, DateEnd);
    }
}
