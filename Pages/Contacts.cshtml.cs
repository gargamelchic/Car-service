using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using GigaChatAdapter;
using System.Net;


namespace WebApplication1.Pages
{
    public class ContactsModel : PageModel
    {
        string authData = "MDE5YmZhYjUtOTgwMC03OTI0LTlmMGYtMjBkMmUwMGQ5MWI1OjgyNDQzNDUzLThmNDQtNDA1MC04ZTQwLTY3NjE1ZDQ0YmY1Yg==";
        
        [BindProperty]
        public AIChatFormModel AIChatForm { get; set; } = new();

        public bool ShowAIResponse { get; set; }
        public string AIResponseText { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            GigaChatAdapter.Authorization auth = new GigaChatAdapter.Authorization(authData, GigaChatAdapter.Auth.RateScope.GIGACHAT_API_PERS);
            var authResult = await auth.SendRequest();

            if (authResult.AuthorizationSuccess)
            {
                Completion completion = new Completion();
                var prompt = "# Инструкция для GigaChat" +
                    "Не используй никаких специальных символов разметки(типа #, *, _, >, ``` и др.) для выделения текста. Избегай добавления лишних знаков препинания, отступов или пустых строк. Ответы должны выглядеть лаконично и естественно, как будто написаны обычным человеком."+
                    "Роль:" +
                    "Ты работаешь помощником на сайте автомастерской G2-Motors. " +
                    "Твоя задача помогать клиентам разбираться с проблемами автомобилей, " +
                    "давать рекомендации по ремонту и диагностике, а также направлять клиентов на услуги G2-Motors(обязательно упоминуть название в сообщении)." +
                    " Основные правила взаимодействия:" +
                    "- Всегда внимательно читай описание проблемы клиента и задавай уточняющие вопросы, если это необходимо." +
                    "- Давай четкие и понятные инструкции, рекомендации и объяснения по устранению неполадок." +
                    "- Используй профессиональные знания в области диагностики и ремонта автомобилей." +
                    "- Если клиент описывает симптомы, предполагай наиболее вероятные причины и рекомендуй соответствующие услуги мастерских G2-Motors." +
                    " Обязательно учитывай марку, модель и пробег автомобиля при рекомендациях." +
                    "- Никогда не давай рекомендаций по самостоятельному ремонту сложных узлов или электронных компонентов." +
                    "- Поддерживай дружелюбный тон общения и убедись, что клиенты чувствуют себя уверенно и спокойно." +
                    " Пример правильного ответа клиенту:" +
                    "Клиент пишет:  " +
                    "Машина плохо заводится утром, двигатель дымит белым дымом, пробег около 80 тыс. км, марка/модель: Toyota Camry V6." +
                    "Отвечаешь:  " +
                    "Похоже, у вас может быть проблема с системой охлаждения или уплотнениями цилиндро-поршневой группы. Специалисты G2-Motors рекомендуют провести комплексную диагностику двигателя и системы охлаждения. Запишитесь на удобное время, и наши мастера оперативно устранят причину белого дыма и восстановят стабильный запуск вашего автомобиля." +
                    "Теперь приступайте к работе." + AIChatForm.AIQuestion;

                await auth.UpdateToken();

                var result = await completion.SendRequest(auth.LastResponse.GigaChatAuthorizationResponse?.AccessToken, prompt);

                if (result.RequestSuccessed)
                {
                    AIResponseText = $"Привет, {AIChatForm.Name ?? "пользователь"}! Ответ:{result.GigaChatCompletionResponse.Choices.LastOrDefault().Message.Content}";
                }
                else
                {
                    AIResponseText = result.ErrorTextIfFailed;
                }
            }
            else
            {
                AIResponseText = authResult.ErrorTextIfFailed;
            }

            ShowAIResponse = true;

            // Очищаем поле вопроса после получения ответа, но оставляем остальные данные
            if (ShowAIResponse)
            {
                AIChatForm.AIQuestion = string.Empty;
                ModelState.Remove("AIChatForm.AIQuestion");
            }

            return Page();
        }

        public class AIChatFormModel
        {
            [Display(Name = "Имя")]
            public string? Name { get; set; }

            [Required(ErrorMessage = "Пожалуйста, введите ваш вопрос")]
            [StringLength(2000, MinimumLength = 5, ErrorMessage = "Вопрос должен содержать от 5 до 2000 символов")]
            [Display(Name = "Ваш вопрос")]
            public string AIQuestion { get; set; } = string.Empty;

            [Required(ErrorMessage = "Необходимо принять условия использования")]
            [Display(Name = "Согласие с условиями")]
            public bool AgreeToTerms { get; set; }
        }
    }
}