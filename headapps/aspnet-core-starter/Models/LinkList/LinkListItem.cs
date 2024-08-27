using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models;

public class LinkListItem 
{
    [JsonPropertyName("field")]
    public LinkListItemField? Field { get; set; }
}