using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models;

public class PartialDesignDynamicPlaceholder : BaseModel
{
    [SitecoreComponentParameter(Name ="sig")]
    public string? Sig { get; set; }
}
