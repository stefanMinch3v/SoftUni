namespace Models.Dtos
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class UserSoldProductsDto
    {
        public UserSoldProductsDto()
        {
            this.SoldProducts = new HashSet<SoldProductDto>();
        }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public virtual ICollection<SoldProductDto> SoldProducts { get; set; }
    }
}
