using Sitecore.AspNetCore.SDK.RenderingEngine.Binding.Attributes;
using System.Text.RegularExpressions;

namespace Sitecore.AspNetCore.Starter.Models
{
    public class Container : BaseModel
    {
        private Regex backgroundImageRegex = new Regex(@"/[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}/gi");

        [SitecoreComponentParameter(Name = "BackgroundImage")]
        public string? BackgroundImage { get; set; }

        public string? BackgroundStyle
        { 
            get
            {
                if (string.IsNullOrEmpty(BackgroundImage))
                {
                    return string.Empty;
                }

                var prefix = $"{(IsEditing ? "/sitecore/shell" : string.Empty + "")}/-/media/";
                var backgroundImageUrl = backgroundImageRegex.Match(BackgroundImage ?? string.Empty).Value.Replace("-", string.Empty);
                return $"backgroundImage: url('{prefix}{backgroundImageUrl}')";
            }
        }

        public bool OutputContainerWrapper 
        {
            get
            {
                return Styles?.Split(' ').Any(x => x == "container") == true;
            }
        }
    }
}
