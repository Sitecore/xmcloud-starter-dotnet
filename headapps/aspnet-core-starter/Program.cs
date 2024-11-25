using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Sitecore.AspNetCore.SDK.GraphQL.Extensions;
using Sitecore.AspNetCore.Starter.Extensions;
using System.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

SitecoreSettings? sitecoreSettings = builder.Configuration.GetSection(SitecoreSettings.Key).Get<SitecoreSettings>();
ArgumentNullException.ThrowIfNull(sitecoreSettings);

builder.Services.AddRouting()
                .AddLocalization()
                .AddMvc();

builder.Services.AddGraphQlClient(configuration =>
                {
                    configuration.ContextId = sitecoreSettings.EdgeContextId;
                })
                .AddMultisite(); 

if (sitecoreSettings.EnableLocalContainer)
{
    // Register the GraphQL version of the Sitecore Layout Service Client for use against local container endpoint
    builder.Services.AddSitecoreLayoutService()
                    .AddGraphQlHandler("default", sitecoreSettings.DefaultSiteName!, sitecoreSettings.EdgeContextId!, sitecoreSettings.LocalContainerLayoutUri!)
                    .AsDefaultHandler();
}
else
{
    // Register the GraphQL version of the Sitecore Layout Service Client for use against experience edge
    builder.Services.AddSitecoreLayoutService()
                    .AddGraphQlWithContextHandler("default", sitecoreSettings.EdgeContextId!, siteName: sitecoreSettings.DefaultSiteName!)
                    .AsDefaultHandler();
}

builder.Services.AddSitecoreRenderingEngine(options =>
                    {
                        options.AddStarterKitViews()
                               .AddDefaultPartialView("_ComponentNotFound");
                    })
                .ForwardHeaders()
                .WithExperienceEditor(options => { options.JssEditingSecret = sitecoreSettings.EditingSecret ?? string.Empty; });

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
    app.UseSitecoreExperienceEditor();
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