using AdministrationApp.Models;
using AdministrationApp.Views;
using AdministrationApp.HelperClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AdministrationApp.ViewModels
{
    /// <summary>
    /// Class that perform Login logic
    /// </summary>
    public partial class LoginViewModel 
    {
        public LoginViewModel(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            this.user = new LoginUserModel();
            CheckCredentials = new LoginButtonCommand(this);
        }

        // Binded to LoginButton and routed to "LoginCommand : ICommand"
        public ICommand CheckCredentials { get; set; }
        // Binded to UserName TextBox 
        public LoginUserModel LoginUser
        {
            get { return user; }
            set { user = value; }
        }

        public void CompareUserNameAndPassword(object sender)
        {
            Hashing hash = new Hashing();
            LoginDbContext dbUser = new LoginDbContext();
            PasswordBox _sender = (PasswordBox)sender;

            List<LoginUserModel> query = (from db in dbUser.Logins
                        where db.UserName == LoginUser.UserName
                        select db).ToList();

            if (query.Count() != 0 && (query.First().PasswordHash == hash.Hash(_sender.Password.ToString())))
            {
                this.loginWindow.DialogResult = true;
                return;
            }

            MessageBox.Show("UserName does not exist!", "Failed to login", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.loginWindow.DialogResult = false;
        }

        private LoginUserModel user;
        private LoginWindow loginWindow;
    }

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
            this.loginViewModel.CompareUserNameAndPassword(parameter);
        }
        #endregion
    }
}
