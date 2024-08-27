using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models;

public class LinkListField
{
    [JsonPropertyName("title")]
    public TextField? Title { get; set; }
}