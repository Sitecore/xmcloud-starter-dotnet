using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models;

public class LinkListChildren
{
    [JsonPropertyName("results")]
    public List<LinkListItem>? Results { get; set; }
}