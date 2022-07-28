using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.WebSite.Models
{
    public class Experience
    {
        public string Id { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Experience>(this);
        
    }
}
