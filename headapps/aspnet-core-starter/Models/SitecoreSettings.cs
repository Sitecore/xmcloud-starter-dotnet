namespace Sitecore.AspNetCore.Starter.Models;

public class SitecoreSettings
{
    public static readonly string Key = "Sitecore";

    public string? DefaultSiteName { get; set; }

    public string? EditingSecret { get; set; }

    public string? EdgeContextId { get; set; }

    public bool EnableEditingMode { get; set; }

    public string? EditingPath { get; set; }

    public bool EnableLocalContainer { get; set; }

    public Uri? LocalContainerLayoutUri { get; set; }
}
