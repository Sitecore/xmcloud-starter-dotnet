using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models.PageContent
{
    public abstract class BaseModel
    {
        [SitecoreContextProperty]
        public bool IsEditing { get; set; }

        [SitecoreComponentProperty(Name = nameof(Component.Id))]
        public string? Id { get; set; }

        [SitecoreComponentProperty(Name = nameof(Component.Name))]
        public string? ComponentName { get; set; }
    }
}
