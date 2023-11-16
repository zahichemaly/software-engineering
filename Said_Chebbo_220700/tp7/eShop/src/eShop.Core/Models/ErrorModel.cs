using System.Text.Json;
using System.Text.Json.Serialization;

namespace eShop.Core.Models
{
    public class ErrorModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
