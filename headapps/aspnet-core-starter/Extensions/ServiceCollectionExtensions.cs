﻿using Sitecore.AspNetCore.SDK.RenderingEngine.Configuration;

namespace Sitecore.AspNetCore.Starter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static RenderingEngineOptions AddStarterKitViews(this RenderingEngineOptions renderingEngineOptions)
        {
            renderingEngineOptions.AddModelBoundView<Title>("Title")
                                  .AddModelBoundView<Container>("Container")
                                  .AddModelBoundView<ColumnSplitter>("ColumnSplitter")
                                  .AddModelBoundView<RowSplitter>("RowSplitter")
                                  .AddModelBoundView<PageContent>("PageContent")
                                  .AddModelBoundView<RichText>("RichText")
                                  .AddModelBoundView<Promo>("Promo")
                                  .AddModelBoundView<LinkList>("LinkList")
                                  .AddModelBoundView<Image>("Image")
                                  .AddModelBoundView<PartialDesignDynamicPlaceholder>("PartialDesignDynamicPlaceholder");
            
            return renderingEngineOptions;
        }
    }
}