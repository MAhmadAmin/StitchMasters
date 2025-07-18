﻿using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;
using Microsoft.AspNetCore.Components;

namespace StitchMaster.Components.Pages
{
    public partial class Signup_Tailor
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string Username, FullName, Email, Password, ConfirmPassword;

        // Error messages  
        private string UsernameError, EmailError, PasswordError, ConfirmPasswordError;

        // Success state  
        private bool SignUpSuccess = false;
        private bool SignupFailure = false;

        private async void CreateAccount()
        {
            ClearErrors();
            bool hasError = false;

            if (UserData.Instance.UsernameExists(Username))
            {
                UsernameError = "Username already exists.";
                hasError = true;
            }

            if (UserData.Instance.EmailExists(Email))
            {
                EmailError = "Email already in use.";
                hasError = true;
            }

            if (!IsStrongPassword(Password))
            {
                PasswordError = "Password must contain both letters and numbers.";
                hasError = true;
            }

            if (Password != ConfirmPassword)
            {
                ConfirmPasswordError = "Passwords do not match.";
                hasError = true;
            }

            if (hasError)
            {
                SignUpSuccess = false;
                return;
            }

            UserRole ur = UserRoleData.Instance.GetRoleByName("Tailor");
            Tailor t = new Tailor(Username, FullName, Email, Password, ur);
            bool result = TailorData.Instance.StoreObject(t);

            if (result)
            {
                SignUpSuccess = true;
                ClearFields();

                await Task.Delay(1500);
                NavigationManager.NavigateTo("/signin");
            }
            else
                SignupFailure = true;
        }

        private bool IsStrongPassword(string pwd)
        {
            return pwd.Any(char.IsLetter) && pwd.Any(char.IsDigit);
        }

        private void ClearErrors()
        {
            UsernameError = EmailError = PasswordError = ConfirmPasswordError = string.Empty;
        }

        private void ClearFields()
        {
            Username = FullName = Email = Password = ConfirmPassword = string.Empty;
        }
    }
}