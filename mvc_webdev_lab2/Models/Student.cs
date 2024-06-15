using System.ComponentModel.DataAnnotations;

namespace mvc_webdev_lab2.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]+$", ErrorMessage = "Фамилия должна содержать только русские символы и начинаться с заглавной буквы.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁ][а-яё]+$", ErrorMessage = "Имя должно содержать только русские символы и начинаться с заглавной буквы.")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[А-ЯЁ][а-яё]*$", ErrorMessage = "Отчество должно содержать только русские символы и начинаться с заглавной буквы.")]
        public string MiddleName { get; set; }

        [Required]
        [RegularExpression(@"^[М]\d+-\d+$", ErrorMessage = "Группа должна состоять из чисел, символа '-' и заглавной буквы 'М' в начале предложения.")]
        public string Group { get; set; }

        [Required]
        [RegularExpression(@"^(\+7|8)?\d{10}$|(\+7|8)?\d{3}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Телефон должен быть в формате +79990000000, 9990000000, +7-999-000-00-00 или 89990000000.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты.")]
        public string Email { get; set; }
    }
}
