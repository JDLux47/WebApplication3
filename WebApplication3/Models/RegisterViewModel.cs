using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Баланс")]
        public decimal Balance { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
