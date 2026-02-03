using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public string InstitutionName { get; set; } = "G2-Motors";
        public string Slogan { get; set; } = "ƒиагностируем быстро, решаем проблемы навсегда.";
        public string Description { get; set; } = "ћы Ч современный центр кузовного ремонта, объединивший высокие технологии восстановлени€ металла с искусством идеальной покраски. ћы возвращаем им первозданный вид и вашу уверенность на дороге.";

        public List<Feature> Features { get; set; }

        public void OnGet()
        {
            Features = new List<Feature>
            {
                new Feature
                {
                    Icon = "fas fa-award",
                    Title = "¬ысокое качество",
                    Description = "ћы гарантируем высокое качество всех предоставл€емых услуг и материалов."
                },
                new Feature
                {
                    Icon = "fas fa-users",
                    Title = "ќпытна€ команда",
                    Description = "Ќаша команда состоит из квалифицированных специалистов с большим опытом работы."
                },
                new Feature
                {
                    Icon = "fas fa-clock",
                    Title = "ѕунктуальность",
                    Description = "ћы всегда соблюдаем сроки выполнени€ работ и договоренности."
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
