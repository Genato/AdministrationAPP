using AdministrationApp.HelperClasses;
using AdministrationApp.Models;
using AdministrationApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AdministrationApp.ViewModels.LoginViewModel
{
    /// <summary>
    /// LoginWindow Commands 
    /// </summary>
    internal class LoginButtonCommand : ICommand
    {
        public LoginButtonCommand(MainModule mainModule, LoginViewModel loginViewModel)
        {
            this.mainModule = mainModule;
            this.loginViewModel = loginViewModel;
        }

        private LoginViewModel loginViewModel;
        private MainModule mainModule;

        // ICommand region
        #region Icommand region
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            Hashing hash = new Hashing();
            LoginDbContext dbUser = new LoginDbContext();
            PasswordBox _sender = (PasswordBox)parameter;

            List<LoginUserModel> query = (from db in dbUser.Logins
                                          where db.UserName == loginViewModel.LoginUser.UserName
                                          select db).ToList();

            if (query.Count() != 0 && (query.First().PasswordHash == hash.Hash(_sender.Password.ToString())))
            {
                MessageBox.Show("Login successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.mainModule.Visibility = System.Windows.Visibility.Visible;
                this.loginViewModel.LoginWindow.Close();
                return;
            }

            MessageBox.Show("Wrong credentials!", "Failed to login", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.loginViewModel.LoginUser.UserName = "";
            this.loginViewModel.LoginWindow.passwordBox.Password= "";
        }
        #endregion
    }
}

