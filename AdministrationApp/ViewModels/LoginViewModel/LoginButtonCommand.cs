using AdministrationApp.HelperClasses;
using AdministrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public LoginButtonCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        private LoginViewModel loginViewModel;

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
                loginViewModel.LoginWindow.DialogResult = true;
                return;
            }

            MessageBox.Show("UserName does not exist!", "Failed to login", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.loginViewModel.LoginWindow.DialogResult = false;
        }
        #endregion
    }
}

