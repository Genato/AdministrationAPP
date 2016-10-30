using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AdministrationApp.Licence
{
    /// <summary>
    /// Class for checking how many application session has been started. 
    /// It's implemented with class System.Threading.Semaphore(system)
    /// </summary>
    class LicenceChecker
    {
        public bool waitSem;
        private Semaphore sem;

        /// <summary>
        /// Add one session to Semaphore.
        /// If counter is at maximum number of bought licence it returns false, if added then it returns true.
        /// </summary>
        /// <returns></returns>
        public bool AddOneSession()
        {
            try
            {
                sem = Semaphore.OpenExisting("AdministrationSessionCounter");
            }
            catch (WaitHandleCannotBeOpenedException)
            {

                sem = new Semaphore(2, 2, "AdministrationSessionCounter");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Please start the application again!!!\n");
            }

            waitSem = sem.WaitOne(100);

            return waitSem;
        }

        /// <summary>
        /// Release Semaphore and decrement counter on Semaphore
        /// </summary>
        public void ReleaseSemaphore()
        {
            sem.Release();
        }

        /// <summary>
        /// Shows MessageBox with information that maximum number of licence are reached and shutdown this application.
        /// </summary>
        public void MaxNumberOfLicence()
        {
            MessageBox.Show("Maximum number of licence is allready used.\nPlease try again later!", "Licence", MessageBoxButton.OK, MessageBoxImage.Information);
            Application.Current.Shutdown();
        }
    }
}
