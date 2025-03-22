using System.Windows;
using System.Windows.Controls;

namespace TO_DO_LIST_EVENT_DRIVEN.Pages
{
    public partial class LoginPage : Page
    {
        private MainWindow mainWindow;

        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow; // Store reference to MainWindow
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (username == "persona4" && password == "1234")
            {
                mainWindow.ShowSidebar(); // Show sidebar
                NavigationService.Navigate(new ProfilePage()); // Navigate to profile
            }
            else
            {
                MessageBox.Show("Invalid username or password. Try again.");
            }
        }
    }
}