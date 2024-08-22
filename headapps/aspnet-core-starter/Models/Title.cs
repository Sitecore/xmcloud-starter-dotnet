using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Properties;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class Title : BaseModel
    {
        [SitecoreComponentField(Name = "data")]            
        public TitleData? Data { get; set; }

        public HyperLinkField Link 
        { 
            get 
            {
                return new HyperLinkField(
                        new HyperLink
                        {
                            Anchor = TitleLocation?.Url?.Path,
                            Title = TitleLocation?.Field?.JsonValue?.Value
                        });
            }
        }

        public TextField Text
        {
            get
            {   
                return new TextField(TitleLocation?.Field?.JsonValue?.Value ?? string.Empty);
            }
        }


        public TitleLocation? TitleLocation
        {
            get
            {
                return Data?.DataSource ?? Data?.ContextItem;                
            }
        }
    }
    public class TitleData
    {
        [JsonPropertyName("datasource")]
        public TitleLocation? DataSource { get; set; }
        [JsonPropertyName("contextItem")]
        public TitleLocation? ContextItem { get; set; }
    }

    public class TitleLocation
    {
        [JsonPropertyName("url")]
        public TitleUrl? Url { get; set; }
        [JsonPropertyName("field")]
        public TitleField? Field { get; set; }
    }

    public class TitleUrl
    {
        [JsonPropertyName("path")]
        public string? Path{ get; set; }
        [JsonPropertyName("siteName")]
        public string? SiteName { get; set; }
    }

    public class TitleField
    {
        [JsonPropertyName("jsonValue")]
        public TitleFieldValue? JsonValue { get; set; }
    }

    public class TitleFieldValue
    {
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

}