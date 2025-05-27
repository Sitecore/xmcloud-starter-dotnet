using Microsoft.AspNetCore.Localization;
using Sitecore.AspNetCore.SDK.GraphQL.Extensions;
using Sitecore.AspNetCore.SDK.Pages.Configuration;
using Sitecore.AspNetCore.SDK.Pages.Extensions;
using Sitecore.AspNetCore.Starter.Extensions;
using System.Globalization;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

SitecoreSettings? sitecoreSettings = builder.Configuration.GetSection(SitecoreSettings.Key).Get<SitecoreSettings>();
PagesOptions? pagesSettings = builder.Configuration.GetSection(PagesOptions.Key).Get<PagesOptions>() ?? new PagesOptions();
ArgumentNullException.ThrowIfNull(sitecoreSettings);

builder.Services.AddRouting()
                .AddLocalization()
                .AddMvc();

builder.Services.AddGraphQLClient(configuration =>
                {
                    configuration.ContextId = sitecoreSettings.EdgeContextId;
                })
                .AddMultisite();

if (sitecoreSettings.EnableLocalContainer)
{
    // Register the GraphQL version of the Sitecore Layout Service Client for use against local container endpoint
    builder.Services.AddSitecoreLayoutService()
                    .AddSitecorePagesHandler()
                    .AddGraphQLHandler("default", sitecoreSettings.DefaultSiteName!, sitecoreSettings.EdgeContextId!, sitecoreSettings.LocalContainerLayoutUri!)
                    .AsDefaultHandler();
}
else
{
    // Register the GraphQL version of the Sitecore Layout Service Client for use against experience edge
    builder.Services.AddSitecoreLayoutService()
                    .AddSitecorePagesHandler()
                    .AddGraphQLWithContextHandler("default", sitecoreSettings.EdgeContextId!, siteName: sitecoreSettings.DefaultSiteName!)
                    .AsDefaultHandler();
}

builder.Services.AddSitecoreRenderingEngine(options =>
                    {
                        options.AddStarterKitViews()
                               .AddDefaultPartialView("_ComponentNotFound");
                    })
                .ForwardHeaders()
                .WithSitecorePages(sitecoreSettings.EdgeContextId ?? string.Empty, options => { options.EditingSecret = sitecoreSettings.EditingSecret; });

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

if (sitecoreSettings.EnableEditingMode)
{
    app.UseSitecorePages(pagesSettings);
}

app.UseRouting();
app.UseMultisite();
app.UseStaticFiles();

const string defaultLanguage = "en";
app.UseRequestLocalization(options =>
    {
        // If you add languages in Sitecore which this site / Rendering Host should support, add them here.
        List<CultureInfo> supportedCultures = [new CultureInfo(defaultLanguage)];
        options.DefaultRequestCulture = new RequestCulture(defaultLanguage, defaultLanguage);
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
        options.UseSitecoreRequestLocalization();
    });

app.MapControllerRoute(
        "error",
        "error",
        new { controller = "Default", action = "Error" }
    );

app.MapSitecoreLocalizedRoute("sitecore", "Index", "Default");
app.MapFallbackToController("Index", "Default");

app.Run();