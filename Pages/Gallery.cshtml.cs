using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static WebApplication1.Pages.ServicesModel;

namespace WebApplication1.Pages
{
    public class GalleryModel : PageModel
    {
        public List<GalleryImage> AllImages { get; set; }

        public void OnGet()
        {
            AllImages = new List<GalleryImage>
            {
                new GalleryImage { src  = "фотки/Работа1.jpg", Title = "Наш офис", Category = "work" },
                new GalleryImage { src  = "фотки/4.jpg", Title = "Достижения", Category = "results" },
                new GalleryImage { src = "фотки/Оборудование1.jpg", Title = "Наша команда", Category = "team" },
                new GalleryImage { src = "фотки/Работа2.jpg", Title = "Процесс работы", Category = "work" },
                new GalleryImage { src = "фотки/4.jpg", Title = "Успешные проекты", Category = "results" },
                new GalleryImage { src = "фотки/Оборудование2.jpg", Title = "Корпоратив", Category = "team" },
                new GalleryImage { src = "фотки/Работа3.jpg", Title = "Оборудование", Category = "work" },
                new GalleryImage { src = "фотки/4.jpg", Title = "Награды", Category = "results" },
                new GalleryImage { src = "фотки/Оборудование3.jpg", Title = "Обучение", Category = "team" }
            }; 
        }

        public List<GalleryImage> GetImagesByCategory(string category)
        {
            return AllImages.Where(img => img.Category == category).ToList();
        }

        public class GalleryImage
        {
            public string src { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
        }
    }
}
