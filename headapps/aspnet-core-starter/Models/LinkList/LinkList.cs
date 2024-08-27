using Sitecore.AspNetCore.SDK.LayoutService.Client.Response.Model.Fields;
using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models.LinkList;

public class LinkList : BaseModel
{
    [SitecoreComponentField(Name = "data")]
    public DataField? Data { get; set; }

    public TextField? Title
    {
        get
        {
            return Data?.Datasource?.Field?.Title;
        }
    }

    public List<LinkListItem> Children 
    { 
        get
        {
            return Data?.Datasource?.Children?.Results ?? [];
        }
    }
}