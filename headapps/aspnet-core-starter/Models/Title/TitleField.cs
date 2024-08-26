using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title
{
    public class TitleField
    {
        [JsonPropertyName("jsonValue")]
        public TitleFieldValue? JsonValue { get; set; }
    }

}