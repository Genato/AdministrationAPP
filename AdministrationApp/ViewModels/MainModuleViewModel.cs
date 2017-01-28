using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationApp.ViewModels
{
    /// <summary>
    /// Class that perform MainModuleWindow logic
    /// </summary>
    public partial class MainModuleViewModel
    {
        public MainModuleViewModel()
        {
            bool userLogin = false;

            while (userLogin != true)
            {
                Views.LoginWindow loginWnd = new Views.LoginWindow();
                userLogin = loginWnd.ShowDialog().Value;
            }
        }
    }
}
