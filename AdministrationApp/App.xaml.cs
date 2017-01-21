using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AdministrationApp.Licence;
using AdministrationApp.Views;


namespace AdministrationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private LicenceChecker licence = new LicenceChecker();

        public App()
        {
            if (!licence.AddOneSession())
            {
                licence.MaxNumberOfLicence();
                Application.Current.Shutdown();
                return;
            }
        }

        ~App()
        {
            if (licence.waitSem)
                licence.ReleaseSemaphore();
        }
    }
}
