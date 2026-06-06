using ArtGallery.Models;

namespace ArtGallery.Services
{
    public interface IPaintingService
    {
        IEnumerable<Painting> GetAll();
        IEnumerable<Painting> GetFeatured();
        IEnumerable<Painting> GetByCategory(string category);
        IEnumerable<Painting> GetAvailable();
        Painting? GetById(int id);
    }
}
