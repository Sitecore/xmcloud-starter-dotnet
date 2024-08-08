using Sitecore.AspNetCore.SDK.RenderingEngine.Configuration;

namespace Sitecore.AspNetCore.Starter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static RenderingEngineOptions AddStarterKitViews(this RenderingEngineOptions renderingEngineOptions)
        {
            renderingEngineOptions.AddModelBoundView<Title>("Title")
                                  .AddModelBoundView<Container>("Container")
                                  .AddModelBoundView<ColumnSplitter>("ColumnSplitter");

            return renderingEngineOptions;
        }
    }
}