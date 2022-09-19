using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    class User
    {
        [Required(ErrorMessage = "Логин не введен!")]
        [MaxLength(20, ErrorMessage = "Логин не должен превышать 20 символов")]
        [RegularExpression(@"_?\w+", ErrorMessage = "Некорректный формат пароля")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль не введен!")]
        [MaxLength(20, ErrorMessage = "Пароль не должен превышать 20 символов")]
        [RegularExpression(@"_?\w+", ErrorMessage = "Некорректный формат пароля")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль!")]
        [MaxLength(20, ErrorMessage = "Пароль не должен превышать 20 символов")]
        [RegularExpression(@"_?\w+", ErrorMessage = "Некорректный формат пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmePassword { get; set; }

        public User(string login, string password, string confirmePassword)
        {
            Login = login;
            Password = password;
            ConfirmePassword = confirmePassword;
        }
    }
}
