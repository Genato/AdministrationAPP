using System.Windows;
using AdministrationApp.ViewModels.LoginViewModel;

namespace AdministrationApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.DataContext = new LoginViewModel(this);
            InitializeComponent();
        }
    }
}
