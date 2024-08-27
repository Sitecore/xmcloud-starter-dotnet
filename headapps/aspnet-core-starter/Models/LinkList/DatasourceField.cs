using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models;

public class DatasourceField
{
    [JsonPropertyName("field")]
    public LinkListField? Field { get; set; }

    [JsonPropertyName("children")]
    public LinkListChildren? Children { get; set; }
}