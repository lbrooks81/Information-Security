using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace InfoSecLab.Components.Pages.Login
{
    public partial class Index : ComponentBase
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
        private bool PasswordValid { get; set; } = true;
        private String PasswordErrorClass => PasswordValid ? String.Empty : "is-invalid";

        private bool LoginSuccess { get; set; } = false;
        private String LoginSuccessfulMsg { get; set; } = String.Empty;

        // This method is called when the component is first initialized
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void PerformLogin()
        {
            // ValidateForm() will return false if the form is invalid. In that case, we don't want to continue.
            if (ValidateForm() == false)
            {
                return;
            }

            //TODO: Your code here
        }

        private bool ValidateForm()
        {
            EmailValid = EmailRegex().IsMatch(Email);
            PasswordValid = String.IsNullOrEmpty(Password) == false;
            return EmailValid && PasswordValid;
        }

        private void LoginSuccessful()
        {
            LoginSuccess = true;
            LoginSuccessfulMsg = $"Welcome back, {Email}!";
            Email = String.Empty;
            Password = String.Empty;
        }
    }
}
