namespace ArtGallery.Models
{
    public class CartItem
    {
        public int PaintingId { get; set; }
        public Painting? Painting { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
