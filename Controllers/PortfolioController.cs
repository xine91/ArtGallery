using Microsoft.AspNetCore.Mvc;
using ArtGallery.Services;
using Microsoft.AspNetCore.Localization;

namespace ArtGallery.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILocalizationService _localization;
        private readonly IPaintingService _paintingService;

        public PortfolioController(ILocalizationService localization, IPaintingService paintingService)
        {
            _localization = localization;
            _paintingService = paintingService;
        }

        public IActionResult Index(string? category)
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            ViewBag.CurrentCategory = category ?? "All";
            
            var paintings = _paintingService.GetByCategory(category ?? "All");
            return View(paintings);
        }

        public IActionResult Details(int id)
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            
            var painting = _paintingService.GetById(id);
            if (painting == null)
            {
                return NotFound();
            }
            return View(painting);
        }

        private string GetCurrentCulture()
        {
            return HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "ru";
        }
    }
}
