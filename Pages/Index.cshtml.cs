using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public string InstitutionName { get; set; } = "Название Учреждения";
        public string Slogan { get; set; } = "Ваш слоган или краткое описание";
        public string Description { get; set; } = "Краткое описание вашего учреждения, его миссии и ценностей. Опишите чем вы занимаетесь и почему клиенты должны выбрать именно вас.";

        public List<Feature> Features { get; set; }

        public void OnGet()
        {
            Features = new List<Feature>
            {
                new Feature
                {
                    Icon = "fas fa-award",
                    Title = "Высокое качество",
                    Description = "Мы гарантируем высокое качество всех предоставляемых услуг и материалов."
                },
                new Feature
                {
                    Icon = "fas fa-users",
                    Title = "Опытная команда",
                    Description = "Наша команда состоит из квалифицированных специалистов с большим опытом работы."
                },
                new Feature
                {
                    Icon = "fas fa-clock",
                    Title = "Пунктуальность",
                    Description = "Мы всегда соблюдаем сроки выполнения работ и договоренности."
                }
            };
        }

        public class Feature
        {
            public string Icon { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
