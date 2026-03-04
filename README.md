# 📄 FormValidator – C# Form Validation Utility

`FormValidator` is a static C# utility class that provides simple and consistent validation for common form fields. It includes both **boolean checks** and **detailed feedback** for invalid inputs.

This makes it easy to integrate in Console apps, ASP.NET forms, or any .NET project where form validation is required.

---

## 🔹 Features

* **Boolean validation methods**: Quickly check if a value is valid.
* **Detailed mistake methods**: Retrieve user-friendly messages describing what is wrong with the input.
* Validates common fields like:

  * Email
  * Phone Number
  * Username
  * Password
  * CNIC (Pakistan format)
  * Postal Code
  * Date (YYYY-MM-DD)

---

## 🔹 Installation

Add the class to your project manually or package it as a library/NuGet package.

```csharp
using ShahG.Utilities;
```

No external dependencies are required other than `System.Text.RegularExpressions`.

---

## 🔹 Usage

### 1️⃣ Boolean Validation

Use `IsCorrectX` methods to check if a field is valid.

```csharp
string email = "test@example.com";

if (FormValidator.IsCorrectEmail(email))
{
    Console.WriteLine("Email is valid.");
}
else
{
    Console.WriteLine("Email is invalid.");
}
```

---

### 2️⃣ Detailed Feedback

Use `GetMistakeInX` methods to get specific validation errors for each field.

```csharp
string password = "abc123";

var mistakes = FormValidator.GetMistakeInPassword(password);

if (mistakes.Count > 0)
{
    foreach (var mistake in mistakes)
        Console.WriteLine(mistake);
}
```

**Output:**

```
Password must be at least 8 characters long.
Password must contain at least one uppercase letter.
Password must contain at least one special character.
```

---

## 🔹 Methods and Descriptions

| Method                                  | Description                                                                     |
| --------------------------------------- | ------------------------------------------------------------------------------- |
| `IsCorrectEmail(string email)`          | Returns `true` if email is valid.                                               |
| `GetMistakeInEmail(string email)`       | Returns list of errors if email is invalid.                                     |
| `IsCorrectPhone(string phone)`          | Returns `true` if phone number is valid. Supports optional `+`, 10–15 digits.   |
| `GetMistakeInPhone(string phone)`       | Returns list of errors if phone number is invalid.                              |
| `IsCorrectUsername(string username)`    | Returns `true` if username is valid (3–20 chars, letters, numbers, underscore). |
| `GetMistakeInUsername(string username)` | Returns list of errors if username is invalid.                                  |
| `IsCorrectPassword(string password)`    | Returns `true` if password meets complexity rules.                              |
| `GetMistakeInPassword(string password)` | Returns detailed password errors (length, letter case, number, special char).   |
| `IsCorrectCNIC(string cnic)`            | Returns `true` if CNIC matches `12345-1234567-1` format.                        |
| `GetMistakeInCNIC(string cnic)`         | Returns errors if CNIC format is invalid.                                       |
| `IsCorrectPostalCode(string code)`      | Returns `true` if postal code is exactly 5 digits.                              |
| `GetMistakeInPostalCode(string code)`   | Returns errors if postal code is invalid.                                       |
| `IsCorrectDateFormat(string date)`      | Returns `true` if date is valid (YYYY-MM-DD).                                   |
| `GetMistakeInDate(string date)`         | Returns errors if date format is wrong or date is invalid.                      |

---

## 🔹 Example Workflow

```csharp
var email = "invalid-email";
var phone = "+923001234567";
var password = "abc";

if (!FormValidator.IsCorrectEmail(email))
{
    Console.WriteLine("Email Errors:");
    FormValidator.GetMistakeInEmail(email).ForEach(Console.WriteLine);
}

if (!FormValidator.IsCorrectPassword(password))
{
    Console.WriteLine("Password Errors:");
    FormValidator.GetMistakeInPassword(password).ForEach(Console.WriteLine);
}

Console.WriteLine("Phone valid? " + FormValidator.IsCorrectPhone(phone));
```

---

## 🔹 Notes

* Regex is used for **format validation**.
* For email, format is validated, not full RFC compliance.
* Phone validation checks structure, not country codes.
* CNIC validation is format-only (not verified with official databases).
* Date validation uses both regex and `DateTime.TryParse`.

---

## 🔹 Next Steps for Developers

* You can extend `FormValidator` to include new fields (e.g., address, credit card).
* Consider returning a `ValidationResult` object for cleaner API in large projects:

```csharp
public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; }
}
```

This makes the API consistent and easier to maintain.

