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

namespace AdministrationApp.ViewModels.LoginViewModel
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
            LoginButton = new LoginButtonCommand(this);
            ExitButton = new ShutdownApplication(this);
        }

        // Binded to UserName TextBox 
        public LoginUserModel LoginUser
        {
            get { return user; }
            set { user = value; }
        }
        public LoginWindow LoginWindow
        {
            get { return loginWindow; }
            set { loginWindow = value; }
        }
        // Binded to LoginButton and routed to "LoginCommand : ICommand"
        public ICommand LoginButton { get; set; }
        // Binded to ExitButton and routed to "ShutdownApplication : ICommand"
        public ICommand ExitButton { get; set; }

        private LoginUserModel user;
        private LoginWindow loginWindow;
    }
}