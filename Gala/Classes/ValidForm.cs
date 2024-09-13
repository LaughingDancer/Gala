using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gala.Classes
{
    internal class ValidForm
    {
        public class Validation
        {
            public bool ValidateLastName(string lastName)
            {
                return Regex.IsMatch(lastName, @"^[а-яА-Яa-zA-Z]+$");
            }
            public bool ValidateFirstName(string firstName)
            {
                return Regex.IsMatch(firstName, @"^[а-яА-Яa-zA-Z]+$");
            }

            public bool ValidateMiddleName(string middleName)
            {
                return Regex.IsMatch(middleName, @"^[а-яА-Яa-zA-Z]+$");
            }

            public bool ValidateEmail(string email)
            {
                return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            }

            public bool ValidateINN(string inn)
            {
                return Regex.IsMatch(inn, @"^\d{10}$|^\d{12}$");
            }
            public bool ValidateNumber(string number)
            {
                return Regex.IsMatch(number, @"^[0-9]+$");
            }
            public bool ValidatePhone(string phone)
            {
                string cleanedPhone = Regex.Replace(phone, @"\D", "");
                if (cleanedPhone.Length != 11)
                    return false;
                if (!Regex.IsMatch(cleanedPhone, @"^7\d{10}$"))
                    return false;
                if (!Regex.IsMatch(cleanedPhone.Substring(1, 3), @"^9[0-9]{2}$"))
                    return false;
                return true;
            }
            public bool ValidateCompanyName(string companyName)
            {
                if (!Regex.IsMatch(companyName, @"^[\p{L}\p{M}'""\s]+$"))
                    return false;
                return true;
            }
            public bool ValidateText(string text)
            {
                if (!Regex.IsMatch(text, @"^[\p{L}\p{M}0-9\s'""\.,\-!@#\$%\^&\*\(\)_\+=\[\]\{\}:;<>\\|\/\?]+$"))
                    return false;
                return true;
            }
        }
    }
}
