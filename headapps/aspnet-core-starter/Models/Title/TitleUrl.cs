using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title
{
    public class TitleUrl
    {
        [JsonPropertyName("path")]
        public string? Path{ get; set; }
        [JsonPropertyName("siteName")]
        public string? SiteName { get; set; }
    }

}