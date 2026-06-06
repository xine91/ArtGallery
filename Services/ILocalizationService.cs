namespace ArtGallery.Services
{
    public interface ILocalizationService
    {
        string Get(string key, string culture);
        Dictionary<string, string> GetAll(string culture);
    }
}
