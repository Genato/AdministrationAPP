using AdministrationApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationApp.ViewModel
{
    class LoginViewModel
    {
        public LoginViewModel()
        {
            bool userLogin = false;

            while (userLogin != true)
            {
                LoginWindow loginWnd = new LoginWindow();
                userLogin = loginWnd.ShowDialog().Value;
            }
        }


    }
}
