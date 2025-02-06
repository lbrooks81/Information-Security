using InfoSecLab.Models;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace InfoSecLab.Components.Pages.Login
{
    public partial class Register : ComponentBase
    {
        private const String EmailPattern = @"^[^@]+@[^@]+\.[^.]+$";

        [GeneratedRegex(EmailPattern)]
        private static partial Regex EmailRegex();

        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        private String Email { get; set; } = String.Empty;
        private bool EmailValid { get; set; } = true;
        private String EmailErrorClass => EmailValid ? String.Empty : "is-invalid";

        private String Password { get; set; } = String.Empty;
        private String PasswordConfirmation { get; set; } = String.Empty;
        private bool PasswordsMatch { get; set; } = true;

        private bool RegistrationSuccess { get; set; } = false;
        private String ReigstrationSuccessfulMsg { get; set; } = String.Empty;

        [Inject]
        private InfoSecDemoContext DbContext { get; set; }
        private void PerformRegister()
        {
            // Reset variables
            EmailValid = true;
            PasswordsMatch = true;
            RegistrationSuccess = false;

            // Email format validation
            if (EmailRegex().IsMatch(Email) == false)
            { 
                EmailValid = false;
                return;
            }

            // Passwords match validation
            if (Password.Equals(PasswordConfirmation) == false)
            {
                PasswordsMatch = false;
                return;
            }

            // Duplicate email validation
            if (DbContext.Users.Any(user => user.UserEmail.Equals(Email, StringComparison.OrdinalIgnoreCase)))
            {
                EmailValid = false;
                return;
            }

            String hashedPassword = HashUtils.HashPassword(Password);
            User user = new User
            {
                UserEmail = Email,
                UserPwdHash = hashedPassword
            };

            DbContext.Users.Add(user);
            DbContext.SaveChanges();
            RegistrationSuccessful();
        }

        private void RegistrationSuccessful()
        {
            RegistrationSuccess = true;
            ReigstrationSuccessfulMsg = $"{Email} registered successfully!";
            Email = String.Empty;
            Password = String.Empty;
            PasswordConfirmation = String.Empty;
        }
    }
}
