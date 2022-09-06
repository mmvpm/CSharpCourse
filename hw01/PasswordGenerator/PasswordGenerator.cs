using System;
using System.Linq;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        private readonly Random _random;

        private const string Underscore = "_";
        private const string Digits = "0123456789";
        private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public PasswordGenerator()
        {
            _random = new Random();
        }

        public string Generate()
        {
            var countUnderscore = 1;
            var passwordLength = _random.Next(6, 21);
            var countUpperCase = _random.Next(2, passwordLength - countUnderscore + 1);
            var countDigits = _random.Next(0, Math.Min(passwordLength - countUnderscore - countUpperCase, 5) + 1);
            var countLowerCase = passwordLength - countUnderscore - countUpperCase - countDigits;

            var digits = RandomChoice(Digits, countDigits);
            var lowerCase = RandomChoice(LowerCaseLetters, countLowerCase);
            var upperCase = RandomChoice(UpperCaseLetters, countUpperCase);

            var password = Underscore + lowerCase + upperCase;
            password = RandomChoice(password, password.Length);
            for (var i = 0; i < digits.Length; ++i)
            {
                password = password.Insert(2 * i, digits[i].ToString());
            }

            return password;
        }
        
        private string RandomChoice(string s, int count)
        {
            return string.Join("", s.OrderBy(_ => _random.Next()).Take(count));
        }
    }
}