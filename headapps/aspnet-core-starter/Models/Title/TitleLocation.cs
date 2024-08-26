using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title
{
    public class TitleLocation
    {
        [JsonPropertyName("url")]
        public TitleUrl? Url { get; set; }
        [JsonPropertyName("field")]
        public TitleField? Field { get; set; }
    }

}