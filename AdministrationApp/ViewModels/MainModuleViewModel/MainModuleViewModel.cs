using AdministrationApp.HelperClasses;
using AdministrationApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AdministrationApp.ViewModels.MainModuleVM
{
    /// <summary>
    /// Class that perform MainModuleWindow logic
    /// </summary>
    public partial class MainModuleViewModel
    {
        public MainModuleViewModel(MainModule mainModule)
        {
            Views.LoginWindow loginWnd = new Views.LoginWindow(mainModule);
            loginWnd.Show();
        }
    }
}
