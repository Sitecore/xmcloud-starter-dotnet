using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title
{
    public class TitleFieldValue
    {
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

}