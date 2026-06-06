using Microsoft.AspNetCore.Mvc;
using ArtGallery.Services;
using Microsoft.AspNetCore.Localization;

namespace ArtGallery.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILocalizationService _localization;
        private readonly IPaintingService _paintingService;

        public ShopController(ILocalizationService localization, IPaintingService paintingService)
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
            
            var paintings = string.IsNullOrEmpty(category) || category == "All"
                ? _paintingService.GetAvailable()
                : _paintingService.GetByCategory(category).Where(p => p.IsAvailable);
            
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

        public IActionResult Cart()
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            return View();
        }

        [HttpPost]
        public IActionResult Checkout()
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            TempData["Success"] = _localization.Get("OrderSuccess", culture);
            return RedirectToAction("Index");
        }

        private string GetCurrentCulture()
        {
            return HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "ru";
        }
    }
}
