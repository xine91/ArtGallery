namespace ArtGallery.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string TitleRu { get; set; } = string.Empty;
        public string TitleEn { get; set; } = string.Empty;
        public string TitleUk { get; set; } = string.Empty;
        public string TitleDe { get; set; } = string.Empty;
        public string DescriptionRu { get; set; } = string.Empty;
        public string DescriptionEn { get; set; } = string.Empty;
        public string DescriptionUk { get; set; } = string.Empty;
        public string DescriptionDe { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Technique { get; set; } = string.Empty;
        public string TechniqueEn { get; set; } = string.Empty;
        public string TechniqueUk { get; set; } = string.Empty;
        public string TechniqueDe { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
        public bool IsFeatured { get; set; } = false;

        public string GetTitle(string culture)
        {
            return culture switch
            {
                "en" => TitleEn,
                "uk" => TitleUk,
                "de" => TitleDe,
                _ => TitleRu
            };
        }

        public string GetDescription(string culture)
        {
            return culture switch
            {
                "en" => DescriptionEn,
                "uk" => DescriptionUk,
                "de" => DescriptionDe,
                _ => DescriptionRu
            };
        }

        public string GetTechnique(string culture)
        {
            return culture switch
            {
                "en" => !string.IsNullOrEmpty(TechniqueEn) ? TechniqueEn : Technique,
                "uk" => !string.IsNullOrEmpty(TechniqueUk) ? TechniqueUk : Technique,
                "de" => !string.IsNullOrEmpty(TechniqueDe) ? TechniqueDe : Technique,
                _ => Technique
            };
        }
    }
}
