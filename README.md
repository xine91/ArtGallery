# Art Gallery - Сайт по продаже картин

## Описание
ASP.NET Core MVC сайт для продажи картин с минималистичным дизайном и двумя темами.

## Страницы
- **Главная** - Приветствие и избранные работы
- **Портфолио** - Все картины с фильтрацией по категориям
- **Магазин** - Доступные для покупки картины с корзиной
- **О художнике** - Информация о художнике
- **Контакты** - Форма обратной связи и контактная информация

## Функции
- 🌍 **Мультиязычность** - Русский, English, Українська, Deutsch
- 🎨 **Две темы**:
  - Светлая (коралловый + бирюзовый)
  - Тёмная (чёрно-белая)
- 🛒 **Корзина покупок** (localStorage)
- 📱 **Адаптивный дизайн**

## Изменение цветов
Цвета легко меняются в файле `wwwroot/css/site.css`:

```css
:root {
    /* Светлая тема - Два ярких гармоничных цвета */
    --primary-color: #FF6B6B;       /* Основной цвет */
    --secondary-color: #4ECDC4;     /* Дополнительный цвет */
    ...
}

[data-theme="dark"] {
    /* Тёмная тема - Чёрно-белая */
    --primary-color: #FFFFFF;
    --secondary-color: #CCCCCC;
    ...
}
```

## Запуск

### Вариант 1: Через командную строку
```bash
cd ArtGallery
dotnet restore
dotnet run
```

### Вариант 2: Двойной клик на файл
Запустите файл `run.bat` - откроется браузер автоматически

Откройте браузер: `https://localhost:5001` или `http://localhost:5000`

## Сборка проекта
Запустите `build.bat` или выполните:
```bash
dotnet build
```

## Технологии
- ASP.NET Core 9.0
- C# / Razor Pages
- CSS3 с переменными
- JavaScript (ES6+)
- Локализация на стороне сервера

## Структура проекта
```
ArtGallery/
├── Controllers/          # MVC контроллеры
├── Models/               # Модели данных
├── Services/             # Сервисы (локализация, картины)
├── Views/                # Razor представления
│   ├── Home/
│   ├── Portfolio/
│   ├── Shop/
│   ├── About/
│   ├── Contacts/
│   └── Shared/
└── wwwroot/              # Статические файлы
    ├── css/
    ├── js/
    └── images/
```

## Добавление картин
Для добавления картин отредактируйте `Services/PaintingService.cs` и добавьте изображения в `wwwroot/images/paintings/`.

Пример:
```csharp
new Painting
{
    Id = 9,
    TitleRu = "Название",
    TitleEn = "Title",
    TitleUk = "Назва",
    TitleDe = "Titel",
    DescriptionRu = "Описание",
    DescriptionEn = "Description",
    DescriptionUk = "Опис",
    DescriptionDe = "Beschreibung",
    Price = 50000,
    ImageUrl = "/images/paintings/your-image.jpg",
    Category = "Landscapes", // Landscapes, Portraits, Abstract, StillLife
    Year = 2024,
    Size = "100x80 см",
    Technique = "Масло, холст",
    TechniqueEn = "Oil on canvas",
    TechniqueUk = "Олія на полотні",
    TechniqueDe = "Öl auf Leinwand",
    IsAvailable = true,
    IsFeatured = true
}
```

## Добавление нового языка
1. Откройте `Program.cs` и добавьте культуру в `supportedCultures`
2. Откройте `Services/LocalizationService.cs` и добавьте словарь переводов
3. Откройте `Views/Shared/_Layout.cshtml` и добавьте кнопку языка
4. Обновите модель `Models/Painting.cs` с новыми свойствами языка
