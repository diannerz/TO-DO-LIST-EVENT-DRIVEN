using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TO_DO_LIST_EVENT_DRIVEN.Pages;

namespace TO_DO_LIST_EVENT_DRIVEN
{
    public partial class MainWindow : Window
    {
        private bool IsUserLoggedIn = false; // Track login status

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage(this)); // Pass MainWindow reference
        }

        public void ShowSidebar()
        {
            IsUserLoggedIn = true;
            SidebarPanel.Visibility = Visibility.Visible;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserLoggedIn)
                MainFrame.Navigate(new ProfilePage());
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserLoggedIn)
                MainFrame.Navigate(new TaskPage());
        }

        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            if (IsUserLoggedIn)
                MainFrame.Navigate(new SummaryPage());
        }
    }
}