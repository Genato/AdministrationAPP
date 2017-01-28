using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdministrationApp.ViewModels.LoginViewModel
{
    class ShutdownApplication : ICommand
    {
        public ShutdownApplication(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        private LoginViewModel loginViewModel;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Environment.Exit(0);
        }
    }
}
