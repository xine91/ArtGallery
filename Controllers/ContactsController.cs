using Microsoft.AspNetCore.Mvc;
using ArtGallery.Services;
using ArtGallery.Models;
using Microsoft.AspNetCore.Localization;

namespace ArtGallery.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILocalizationService _localization;

        public ContactsController(ILocalizationService localization)
        {
            _localization = localization;
        }

        public IActionResult Index()
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;
            return View(new ContactViewModel());
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            var culture = GetCurrentCulture();
            ViewBag.Loc = _localization.GetAll(culture);
            ViewBag.Culture = culture;

            if (ModelState.IsValid)
            {
                // Здесь можно добавить логику отправки email
                TempData["Success"] = _localization.Get("MessageSent", culture);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private string GetCurrentCulture()
        {
            return HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name ?? "ru";
        }
    }
}
