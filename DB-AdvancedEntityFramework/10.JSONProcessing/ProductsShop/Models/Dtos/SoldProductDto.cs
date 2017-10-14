using Newtonsoft.Json;

namespace Models.Dtos
{
    public class SoldProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string FirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string LastName { get; set; }
    }
}
