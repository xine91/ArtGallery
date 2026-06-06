using Microsoft.AspNetCore.Mvc;
using ArtGallery.Services;
using Microsoft.AspNetCore.Localization;

namespace ArtGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocalizationService _localization;
        private readonly IPaintingService _paintingService;

        public HomeController(ILocalizationService localization, IPaintingService paintingService)
        {
            _localization = localization;
            _paintingService = paintingService;
        }

        public IActionResult Index()
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            ViewBag.FeaturedPaintings = _paintingService.GetFeatured();
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl ?? "/");
        }

        public IActionResult Error()
        {
            return View();
        }

        private string GetCurrentCulture()
        {
            return HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "ru";
        }
    }
}
