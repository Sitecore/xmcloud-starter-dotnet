using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class LinkList : BaseModel
    {
        [SitecoreComponentField(Name = "data")]
        public DataField? Data { get; set; }

        public TextField? Title
        {
            get
            {
                return Data?.Datasource?.Field?.Title;
            }
        }

        public List<LinkListItem> Children 
        { 
            get
            {
                return Data?.Datasource?.Children?.Results ?? [];
            }
        }
    }

    public class DataField
    {
        [JsonPropertyName("datasource")]
        public DatasourceField? Datasource { get; set; }
    }

    public class DatasourceField
    {
        [JsonPropertyName("field")]
        public LinkListField? Field { get; set; }

        [JsonPropertyName("children")]
        public LinkListChildren? Children { get; set; }
    }

    public class LinkListChildren
    {
        [JsonPropertyName("results")]
        public List<LinkListItem>? Results { get; set; }
    }

    public class LinkListItem 
    {
        [JsonPropertyName("field")]
        public LinkListItemField? Field { get; set; }
    }

    public class LinkListItemField
    {
        [JsonPropertyName("link")]
        public HyperLinkField? Link { get; set; }
    }

    public class LinkListField
    {
        [JsonPropertyName("title")]
        public TextField? Title { get; set; }
    }

}