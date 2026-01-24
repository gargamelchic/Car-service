using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class GalleryModel : PageModel
    {
        public List<GalleryImage> AllImages { get; set; }

        public void OnGet()
        {
            AllImages = new List<GalleryImage>
            {
                new GalleryImage { Url = "https://via.placeholder.com/400x300/007bff/ffffff?text=Работа+1", Title = "Наш офис", Category = "work" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/28a745/ffffff?text=Результат+1", Title = "Достижения", Category = "results" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/dc3545/ffffff?text=Команда+1", Title = "Наша команда", Category = "team" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/ffc107/000000?text=Работа+2", Title = "Процесс работы", Category = "work" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/17a2b8/ffffff?text=Результат+2", Title = "Успешные проекты", Category = "results" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/6c757d/ffffff?text=Команда+2", Title = "Корпоратив", Category = "team" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/343a40/ffffff?text=Работа+3", Title = "Оборудование", Category = "work" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/007bff/ffffff?text=Результат+3", Title = "Награды", Category = "results" },
                new GalleryImage { Url = "https://via.placeholder.com/400x300/28a745/ffffff?text=Команда+3", Title = "Обучение", Category = "team" }
            };
        }

        public List<GalleryImage> GetImagesByCategory(string category)
        {
            return AllImages.Where(img => img.Category == category).ToList();
        }

        public class GalleryImage
        {
            public string Url { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
        }
    }
}
