using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class ServicesModel : PageModel
    {
        public List<Service> Services { get; set; }

        public void OnGet()
        {
            Services = new List<Service>
            {
                new Service
                {
                    Icon = "fas fa-briefcase",
                    Title = "Консультации",
                    Description = "Профессиональные консультации по всем вопросам нашей деятельности",
                    Items = new List<string>
                    {
                        "Персональный подход к каждому клиенту",
                        "Подробный анализ ситуации",
                        "Рекомендации по дальнейшим действиям",
                        "Поддержка после консультации"
                    },
                    Price = "от 1 500 ?"
                },
                new Service
                {
                    Icon = "fas fa-cogs",
                    Title = "Основные услуги",
                    Description = "Полный спектр основных услуг нашего учреждения",
                    Items = new List<string>
                    {
                        "Качественное выполнение работ",
                        "Использование современных технологий",
                        "Соблюдение сроков",
                        "Гарантия на все виды работ"
                    },
                    Price = "Индивидуальный расчет"
                },
                new Service
                {
                    Icon = "fas fa-star",
                    Title = "Премиум услуги",
                    Description = "Расширенные услуги для самых требовательных клиентов",
                    Items = new List<string>
                    {
                        "Экспресс-обслуживание",
                        "Индивидуальные решения",
                        "Приоритетная поддержка",
                        "Расширенная гарантия"
                    },
                    Price = "По договоренности"
                }
            };
        }

        public class Service
        {
            public string Icon { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public List<string> Items { get; set; }
            public string Price { get; set; }
        }
    }
}
