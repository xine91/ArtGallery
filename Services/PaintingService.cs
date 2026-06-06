using ArtGallery.Models;

namespace ArtGallery.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly List<Painting> _paintings = new()
        {
            new Painting
            {
                Id = 1,
                TitleRu = "Рассвет над морем",
                TitleEn = "Sunrise Over the Sea",
                TitleUk = "Світанок над морем",
                TitleDe = "Sonnenaufgang über dem Meer",
                DescriptionRu = "Величественный рассвет над спокойным морем, отражающий красоту природы.",
                DescriptionEn = "Majestic sunrise over a calm sea, reflecting the beauty of nature.",
                DescriptionUk = "Величний світанок над спокійним морем, що відображає красу природи.",
                DescriptionDe = "Majestätischer Sonnenaufgang über einem ruhigen Meer, der die Schönheit der Natur widerspiegelt.",
                Price = 45000,
                ImageUrl = "/images/paintings/lighthouse.jpg",
                Category = "Landscapes",
                Year = 2024,
                Size = "80x60 см",
                Technique = "Масло, холст",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                IsAvailable = true,
                IsFeatured = true
            },
            new Painting
            {
                Id = 2,
                TitleRu = "Горный пейзаж",
                TitleEn = "Mountain Landscape",
                TitleUk = "Гірський пейзаж",
                TitleDe = "Berglandschaft",
                DescriptionRu = "Заснеженные вершины гор в лучах заходящего солнца.",
                DescriptionEn = "Snow-capped mountain peaks in the rays of the setting sun.",
                DescriptionUk = "Засніжені вершини гір у променях заходячого сонця.",
                DescriptionDe = "Schneebedeckte Berggipfel im Licht der untergehenden Sonne.",
                Price = 55000,
                ImageUrl = "/images/paintings/mountains.jpg",
                Category = "Landscapes",
                Year = 2023,
                Size = "100x70 см",
                Technique = "Масло, холст",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                IsAvailable = true,
                IsFeatured = true
            },
            new Painting
            {
                Id = 3,
                TitleRu = "Портрет незнакомки",
                TitleEn = "Portrait of a Stranger",
                TitleUk = "Портрет незнайомки",
                TitleDe = "Porträt einer Fremden",
                DescriptionRu = "Загадочный портрет молодой женщины с глубоким взглядом.",
                DescriptionEn = "Mysterious portrait of a young woman with a deep gaze.",
                DescriptionUk = "Загадковий портрет молодої жінки з глибоким поглядом.",
                DescriptionDe = "Geheimnisvolles Porträt einer jungen Frau mit tiefem Blick.",
                Price = 75000,
                ImageUrl = "/images/paintings/field.jpg",
                Category = "Portraits",
                Year = 2024,
                Size = "60x80 см",
                Technique = "Масло, холст",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                IsAvailable = true,
                IsFeatured = true
            },
            new Painting
            {
                Id = 4,
                TitleRu = "Абстрактная композиция",
                TitleEn = "Abstract Composition",
                TitleUk = "Абстрактна композиція",
                TitleDe = "Abstrakte Komposition",
                DescriptionRu = "Яркая абстрактная работа, наполненная энергией и движением.",
                DescriptionEn = "Bright abstract work filled with energy and movement.",
                DescriptionUk = "Яскрава абстрактна робота, наповнена енергією та рухом.",
                DescriptionDe = "Helle abstrakte Arbeit voller Energie und Bewegung.",
                Price = 35000,
                ImageUrl = "/images/paintings/horse.jpg",
                Category = "Abstract",
                TechniqueEn = "Acrylic on canvas",
                TechniqueUk = "Акрил на полотні",
                TechniqueDe = "Acryl auf Leinwand",
                Year = 2024,
                Size = "90x90 см",
                Technique = "Акрил, холст",
                IsAvailable = true,
                IsFeatured = false
            },
            new Painting
            {
                Id = 5,
                TitleRu = "Цветочный натюрморт",
                TitleEn = "Floral Still Life",
                TitleUk = "Квітковий натюрморт",
                TitleDe = "Blumenstilleben",
                DescriptionRu = "Нежный букет полевых цветов в старинной вазе.",
                DescriptionEn = "Delicate bouquet of wildflowers in an antique vase.",
                DescriptionUk = "Ніжний букет польових квітів у старовинній вазі.",
                DescriptionDe = "Zarter Strauß aus Wildblumen in einer antiken Vase.",
                Price = 28000,
                ImageUrl = "/images/paintings/twoEating.jpg",
                Category = "StillLife",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                Year = 2023,
                Size = "50x60 см",
                Technique = "Масло, холст",
                IsAvailable = true,
                IsFeatured = false
            },
            new Painting
            {
                Id = 6,
                TitleRu = "Осенний лес",
                TitleEn = "Autumn Forest",
                TitleUk = "Осінній ліс",
                TitleDe = "Herbstwald",
                DescriptionRu = "Золотая осень в старом парке, ковер из опавших листьев.",
                DescriptionEn = "Golden autumn in an old park, a carpet of fallen leaves.",
                DescriptionUk = "Золота осінь у старому парку, килим з опалого листя.",
                DescriptionDe = "Goldener Herbst in einem alten Park, ein Teppich aus gefallenen Blättern.",
                Price = 42000,
                ImageUrl = "/images/paintings/beach.jpg",
                Category = "Landscapes",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                Year = 2024,
                Size = "70x50 см",
                Technique = "Масло, холст",
                IsAvailable = true,
                IsFeatured = true
            },
            new Painting
            {
                Id = 7,
                TitleRu = "Городские огни",
                TitleEn = "City Lights",
                TitleUk = "Міські вогні",
                TitleDe = "Stadtlichter",
                DescriptionRu = "Ночной город с яркими огнями и отражениями в воде.",
                DescriptionEn = "Night city with bright lights and reflections in the water.",
                DescriptionUk = "Нічне місто з яскравими вогнями та відображеннями у воді.",
                DescriptionDe = "Nächtliche Stadt mit hellen Lichtern und Reflexionen im Wasser.",
                Price = 65000,
                ImageUrl = "/images/paintings/flowerField.jpg",
                Category = "Landscapes",
                TechniqueEn = "Oil on canvas",
                TechniqueUk = "Олія на полотні",
                TechniqueDe = "Öl auf Leinwand",
                IsAvailable = false,
                IsFeatured = false,
                Technique = "Масло, холст"
            },
            new Painting
            {
                Id = 8,
                TitleRu = "Медитация",
                TitleEn = "Meditation",
                TitleUk = "Медитація",
                TitleDe = "Meditation",
                DescriptionRu = "Спокойная абстрактная работа в пастельных тонах.",
                DescriptionEn = "Calm abstract work in pastel colors.",
                DescriptionUk = "Спокійна абстрактна робота у пастельних тонах.",
                TechniqueEn = "Acrylic on canvas",
                TechniqueUk = "Акрил на полотні",
                TechniqueDe = "Acryl auf Leinwand",
                DescriptionDe = "Ruhige abstrakte Arbeit in Pastellfarben.",
                Price = 38000,
                ImageUrl = "/images/paintings/river.jpg",
                Category = "Abstract",
                Year = 2023,
                Size = "80x80 см",
                Technique = "Акрил, холст",
                IsAvailable = true,
                IsFeatured = false
            }
        };

        public IEnumerable<Painting> GetAll() => _paintings;

        public IEnumerable<Painting> GetFeatured() => _paintings.Where(p => p.IsFeatured);

        public IEnumerable<Painting> GetByCategory(string category) =>
            string.IsNullOrEmpty(category) || category == "All"
                ? _paintings
                : _paintings.Where(p => p.Category == category);

        public IEnumerable<Painting> GetAvailable() => _paintings.Where(p => p.IsAvailable);

        public Painting? GetById(int id) => _paintings.FirstOrDefault(p => p.Id == id);
    }
}
