namespace Sitecore.AspNetCore.Starter.Models
{
    public class SitecoreSettings
    {
        public static readonly string Key = "Sitecore";

        public Uri? InstanceUri { get; set; }

        public string LayoutServicePath { get; set; } = "/api/graphql/v1";

        public string? DefaultSiteName { get; set; }

        public string? ExperienceEdgeToken { get; set; }

        public string? EditingSecret { get; set; }

        public bool EnableEditingMode { get; set; } = false;

        public Uri? LayoutServiceUri
        {
            get
            {
                if (InstanceUri == null)
                {
                    return null;
                }

                return new Uri(InstanceUri, LayoutServicePath);
            }
        }
    }
}
