using System.Text.Json.Serialization;

namespace Sitecore.AspNetCore.Starter.Models.Title;

public class TitleData
{
    public TitleLocation? DataSource { get; set; }
    public TitleLocation? ContextItem { get; set; }
}