using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title
{
    public class TitleData
    {
        [JsonPropertyName("datasource")]
        public TitleLocation? DataSource { get; set; }
        [JsonPropertyName("contextItem")]
        public TitleLocation? ContextItem { get; set; }
    }

}