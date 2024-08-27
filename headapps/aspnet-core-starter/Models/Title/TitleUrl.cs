using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title;

public class TitleUrl
{
    public string? Path{ get; set; }
    public string? SiteName { get; set; }
}