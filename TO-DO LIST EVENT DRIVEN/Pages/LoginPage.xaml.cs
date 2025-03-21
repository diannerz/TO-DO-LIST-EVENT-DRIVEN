using System.Windows;
using System.Windows.Controls;

namespace TO_DO_LIST_EVENT_DRIVEN.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (username == "persona4" && password == "1234")
            {
                NavigationService.Navigate(new ProfilePage());
            }
            else
            {
                MessageBox.Show("Invalid username or password. Try again.");
            }
        }
    }
}
