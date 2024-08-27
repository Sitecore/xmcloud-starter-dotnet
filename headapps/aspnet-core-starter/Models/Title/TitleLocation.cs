using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title;

public class TitleLocation
{
    public TitleUrl? Url { get; set; }
    public TitleField? Field { get; set; }
}