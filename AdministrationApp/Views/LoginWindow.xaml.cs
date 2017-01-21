using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdministrationApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Application.Current.Shutdown();
        }

        private void button1Login_Click(object sender, RoutedEventArgs e)
        {
            String username, password;

            username = textBoxUsername.Text.ToString();
            password = passwordBox.Password.ToString();

            this.DialogResult = false;
            //Hashing...
        }
    }
}
