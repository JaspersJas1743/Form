using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WpfApp1.Models;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Utility
{
    static class Authorization
    {
        public async static Task<User> AsyncSignIn(string login, string password)
        {
            User user = new(login, password, password);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
                foreach (var error in results)
                    throw new AuthorizeExceptions(error.ErrorMessage);

            var data = await new Document(@"C:\Users\206955\Desktop\data.txt").AsyncGetData();
            foreach (var item in data)
                if (new[]{item[0], item[1] } != new[] { login, password })
                    throw new AuthorizeExceptions("Такого пользователя не существует!");

            return user;
        }

        public async static Task<User> AsyncRegistration(string login, string password, string confirmePassword)
        {
            User user = new(login, password, confirmePassword);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
                foreach (var error in results)
                    throw new AuthorizeExceptions(error.ErrorMessage);

            await new Document(@"C:\Users\206955\Desktop\data.txt").AsyncWriteData($"{login} {password}");
            return user;
        }
    }
}
