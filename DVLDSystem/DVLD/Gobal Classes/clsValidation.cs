using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DVLDSystem.Gobal_Classes
{
    public static class clsValidation
    {
        public static bool ValidateEmail(string Email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);

            return regex.IsMatch(Email);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";
            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        public static bool IsEmpty(string Text)
        {
            return string.IsNullOrEmpty(Text);
        }

        public static int CalculateAge(DateTime DateOfBirth)
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
    }
}