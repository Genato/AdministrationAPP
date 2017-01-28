using System.Windows;
using AdministrationApp.ViewModels.LoginViewModel;
using AdministrationApp.ViewModels.MainModuleVM;

namespace AdministrationApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(MainModule mainModule)
        {
            this.DataContext = new LoginViewModel(mainModule, this);
            InitializeComponent();
        }
    }
}
