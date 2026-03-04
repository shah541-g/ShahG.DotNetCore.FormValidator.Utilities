using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ShahG.Utilities
{
    public static class FormValidator
    {
        public static bool IsCorrectEmail(string email)
            => GetMistakeInEmail(email).Count == 0;

        public static List<string> GetMistakeInEmail(string email)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(email))
            {
                mistakes.Add("Email cannot be empty.");
                return mistakes;
            }

            if (!email.Contains("@"))
                mistakes.Add("Email must contain '@' symbol.");

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                mistakes.Add("Email format is invalid (example: example@mail.com).");

            return mistakes;
        }

        public static bool IsCorrectPhone(string phone)
            => GetMistakeInPhone(phone).Count == 0;

        public static List<string> GetMistakeInPhone(string phone)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(phone))
            {
                mistakes.Add("Phone number cannot be empty.");
                return mistakes;
            }

            if (!Regex.IsMatch(phone, @"^\+?\d+$"))
                mistakes.Add("Phone number can contain only digits and optional '+' at the start.");

            if (Regex.Replace(phone, @"\D", "").Length < 10)
                mistakes.Add("Phone number must contain at least 10 digits.");

            if (Regex.Replace(phone, @"\D", "").Length > 15)
                mistakes.Add("Phone number cannot exceed 15 digits.");

            return mistakes;
        }

        public static bool IsCorrectUsername(string username)
            => GetMistakeInUsername(username).Count == 0;

        public static List<string> GetMistakeInUsername(string username)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(username))
            {
                mistakes.Add("Username cannot be empty.");
                return mistakes;
            }

            if (username.Length < 3 || username.Length > 20)
                mistakes.Add("Username must be between 3 and 20 characters.");

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                mistakes.Add("Username can contain only letters, numbers, and underscore.");

            return mistakes;
        }

        public static bool IsCorrectPassword(string password)
            => GetMistakeInPassword(password).Count == 0;

        public static List<string> GetMistakeInPassword(string password)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(password))
            {
                mistakes.Add("Password cannot be empty.");
                return mistakes;
            }

            if (password.Length < 8)
                mistakes.Add("Password must be at least 8 characters long.");

            if (!Regex.IsMatch(password, @"[a-z]"))
                mistakes.Add("Password must contain at least one lowercase letter.");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                mistakes.Add("Password must contain at least one uppercase letter.");

            if (!Regex.IsMatch(password, @"\d"))
                mistakes.Add("Password must contain at least one number.");

            if (!Regex.IsMatch(password, @"[\W_]"))
                mistakes.Add("Password must contain at least one special character.");

            return mistakes;
        }

        public static bool IsCorrectCNIC(string cnic)
            => GetMistakeInCNIC(cnic).Count == 0;

        public static List<string> GetMistakeInCNIC(string cnic)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(cnic))
            {
                mistakes.Add("CNIC cannot be empty.");
                return mistakes;
            }

            if (!Regex.IsMatch(cnic, @"^\d{5}-\d{7}-\d{1}$"))
                mistakes.Add("CNIC must be in format 12345-1234567-1.");

            return mistakes;
        }

        public static bool IsCorrectPostalCode(string code)
            => GetMistakeInPostalCode(code).Count == 0;

        public static List<string> GetMistakeInPostalCode(string code)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(code))
            {
                mistakes.Add("Postal code cannot be empty.");
                return mistakes;
            }

            if (!Regex.IsMatch(code, @"^\d{5}$"))
                mistakes.Add("Postal code must contain exactly 5 digits.");

            return mistakes;
        }

        public static bool IsCorrectDateFormat(string date)
            => GetMistakeInDate(date).Count == 0;

        public static List<string> GetMistakeInDate(string date)
        {
            var mistakes = new List<string>();

            if (string.IsNullOrWhiteSpace(date))
            {
                mistakes.Add("Date cannot be empty.");
                return mistakes;
            }

            if (!Regex.IsMatch(date, @"^\d{4}-\d{2}-\d{2}$"))
                mistakes.Add("Date must be in format YYYY-MM-DD.");
            else if (!DateTime.TryParse(date, out _))
                mistakes.Add("Date is not a valid calendar date.");

            return mistakes;
        }
    }
}