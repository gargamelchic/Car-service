using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class AboutModel : PageModel
    {
        public string AboutText { get; set; } = "Ќаше учреждение было основано с целью предоставлени€ высококачественных услуг нашим клиентам. «а годы работы мы накопили значительный опыт и завоевали доверие множества клиентов. ћы посто€нно развиваемс€, внедр€ем новые технологии и совершенствуем наши методы работы, чтобы соответствовать самым высоким стандартам качества.";

        public List<MissionItem> Missions { get; set; }
        public List<string> Values { get; set; }

        public void OnGet()
        {
            Missions = new List<MissionItem>
            {
                new MissionItem
                {
                    Icon = "fas fa-bullseye",
                    Title = " ачество услуг",
                    Description = "ѕредоставление услуг высочайшего качества дл€ каждого клиента."
                },
                new MissionItem
                {
                    Icon = "fas fa-handshake",
                    Title = "ƒоверие клиентов",
                    Description = "ѕостроение долгосрочных отношений, основанных на взаимном доверии."
                },
                new MissionItem
                {
                    Icon = "fas fa-chart-line",
                    Title = "ѕосто€нное развитие",
                    Description = "Ќепрерывное совершенствование и внедрение инноваций."
                },
                new MissionItem
                {
                    Icon = "fas fa-users",
                    Title = " омандна€ работа",
                    Description = "—оздание сильной команды профессионалов дл€ достижени€ общих целей."
                }
            };

            Values = new List<string>
            {
                "ѕрофессионализм во всем, что мы делаем",
                "„естность и прозрачность в отношени€х с клиентами",
                "ќтветственность за результаты нашей работы",
                "”важение к каждому клиенту и сотруднику",
                "»нновационный подход к решению задач",
                "«абота о качестве и детал€х"
            };
        }

        public class MissionItem
        {
            public string Icon { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
