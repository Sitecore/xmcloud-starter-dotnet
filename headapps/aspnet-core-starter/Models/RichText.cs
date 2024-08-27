using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

public class RichText : BaseModel
{
    [SitecoreComponentField]
    public RichTextField? Text { get; set; }
}
