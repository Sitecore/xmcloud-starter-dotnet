var builder = WebApplication.CreateBuilder(args);

var sitecoreSettings = builder.Configuration.GetSection(SitecoreSettings.Key).Get<SitecoreSettings>();
ArgumentNullException.ThrowIfNull(sitecoreSettings);

builder.Services.AddRouting()
                .AddLocalization()
                .AddMvc();

builder.Services.AddSitecoreLayoutService()
                .AddSystemTextJson()
                .AddGraphQlHandler("default", sitecoreSettings.DefaultSiteName!, sitecoreSettings.ExperienceEdgeToken!, sitecoreSettings.LayoutServiceUri!)
                .AsDefaultHandler();

builder.Services.AddSitecoreRenderingEngine(options =>
                    {
                        options.AddDefaultPartialView("_ComponentNotFound");
                    })
                .ForwardHeaders();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseStaticFiles();

app.UseRequestLocalization(options =>
{
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