﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gala.Classes
{
    internal class ValidationLogin
    {
        public bool Validation(string login)
        {
            var input = login;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле с логином пустое", "Ошибка");
                return false;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Логин должен содержать хотя бы одну строчную букву", "Ошибка");
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                MessageBox.Show("Логин должен содержать хотя бы одну заглавную букву", "Ошибка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Логин должен быть длиннее 6 символов", "Ошибка");
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                MessageBox.Show("Логин должен содержать хотя бы одно числовое значение", "Ошибка");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
