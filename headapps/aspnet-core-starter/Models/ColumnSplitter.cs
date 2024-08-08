using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class ColumnSplitter : BaseModel
    {
        [SitecoreComponentParameter]
        public string? EnabledPlaceholders { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth1 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth2 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth3 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth4 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth5 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth6 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth7 { get; set; }
        [SitecoreComponentParameter]
        public string? ColumnWidth8 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles1 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles2 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles3 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles4 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles5 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles6 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles7 { get; set; }
        [SitecoreComponentParameter]
        public string? Styles8 { get; set; }

        public string[] ColumnWidths
        {
            get
            {
                return
                [
                    ColumnWidth1 ?? string.Empty,
                    ColumnWidth2 ?? string.Empty,
                    ColumnWidth3 ?? string.Empty,
                    ColumnWidth4 ?? string.Empty,
                    ColumnWidth5 ?? string.Empty,
                    ColumnWidth6 ?? string.Empty,
                    ColumnWidth7 ?? string.Empty,
                    ColumnWidth8 ?? string.Empty,
                ];
            }
        }

        public string[] ColumnStyles
        {
            get
            {
                return
                [
                    Styles1 ?? string.Empty,
                    Styles2 ?? string.Empty,
                    Styles3 ?? string.Empty,
                    Styles4 ?? string.Empty,
                    Styles5 ?? string.Empty,
                    Styles6 ?? string.Empty,
                    Styles7 ?? string.Empty,
                    Styles8 ?? string.Empty,
                ];
            }
        }

        public int[] EnabledPlaceholderIds
{
            get
            {
                return EnabledPlaceholders?.Split(',').Select(int.Parse).ToArray() ?? [];
            }
        }
    }
}
