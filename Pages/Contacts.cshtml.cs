using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class ContactsModel : PageModel
    {
        [BindProperty]
        public ContactFormModel ContactForm { get; set; } = new();

        public bool ShowSuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Здесь обычно происходит отправка email или сохранение в базу данных
            // Для примера просто покажем сообщение об успехе

            ShowSuccessMessage = true;

            // Очищаем форму после успешной отправки
            if (ShowSuccessMessage)
            {
                ContactForm = new ContactFormModel();
                ModelState.Clear();
            }

            return Page();
        }

        public class ContactFormModel
        {
            [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
            [Display(Name = "Имя")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Пожалуйста, введите email")]
            [EmailAddress(ErrorMessage = "Некорректный email адрес")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Phone(ErrorMessage = "Некорректный номер телефона")]
            [Display(Name = "Телефон")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Пожалуйста, выберите тему")]
            [Display(Name = "Тема")]
            public string Subject { get; set; }

            [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
            [StringLength(1000, MinimumLength = 10, ErrorMessage = "Сообщение должно содержать от 10 до 1000 символов")]
            [Display(Name = "Сообщение")]
            public string Message { get; set; }

            [Required(ErrorMessage = "Необходимо согласие на обработку данных")]
            [Display(Name = "Согласие на обработку")]
            public bool AgreeToPrivacy { get; set; }
        }
    }
}
