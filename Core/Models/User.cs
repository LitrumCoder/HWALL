using System.ComponentModel.DataAnnotations;

namespace UserRegistrationApp.Core.Models
{
    public class User
    {
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Возраст обязателен для заполнения")]
        [Range(1, 120, ErrorMessage = "Возраст должен быть от 1 до 120 лет")]
        public int Age { get; set; }

        public bool IsAdult => Age >= 18;
    }
}
