using Microsoft.AspNetCore.Mvc;
using ArtGallery.Services;
using Microsoft.AspNetCore.Localization;

namespace ArtGallery.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILocalizationService _localization;

        public AboutController(ILocalizationService localization)
        {
            _localization = localization;
        }

        public IActionResult Index()
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            return View();
        }

        private string GetCurrentCulture()
        {
            return HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "ru";
        }
    }
}
