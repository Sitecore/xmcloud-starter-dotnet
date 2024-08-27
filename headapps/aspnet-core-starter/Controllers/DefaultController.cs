using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNetCore.SDK.LayoutService.Client.Exceptions;
using Sitecore.AspNetCore.SDK.RenderingEngine.Attributes;
using Sitecore.AspNetCore.SDK.RenderingEngine.Interfaces;

namespace Sitecore.AspNetCore.Starter.Controllers
{
    public class DefaultController : Controller
    {
        private SitecoreSettings? settings;
        private readonly ILogger<DefaultController> logger;

        public DefaultController(ILogger<DefaultController> logger, IConfiguration configuration)
        {
            settings = configuration.GetSection(SitecoreSettings.Key).Get<SitecoreSettings>();
            ArgumentNullException.ThrowIfNull(settings);
            this.logger = logger;
        }

        [UseSitecoreRendering]
        public IActionResult Index(Layout model)
        {
            var request = HttpContext.GetSitecoreRenderingContext();
            if ((request?.Response?.HasErrors ?? false) && !IsPageEditingRequest(request))
            {
                foreach (SitecoreLayoutServiceClientException error in request.Response.Errors)
                {
                    switch (error)
                    {
                        default:
                            logger.LogError(error, error.Message);
                            throw error;
                    }
                }
            }
                
            return View(model);
        }

        private bool IsPageEditingRequest(ISitecoreRenderingContext request)
        {
            return request.Controller?.HttpContext.Request.Path == (settings?.EditingPath ?? string.Empty);
        }
    }
}
