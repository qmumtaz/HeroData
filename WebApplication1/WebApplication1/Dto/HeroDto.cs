using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class HeroDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("health")]
        public int Health { get; set; }
    }
}