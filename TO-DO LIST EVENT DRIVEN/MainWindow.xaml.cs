using System.Windows;
using System.Windows.Controls;
using TO_DO_LIST_EVENT_DRIVEN.Pages;

namespace TO_DO_LIST_EVENT_DRIVEN
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TaskPage());
        }

        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SummaryPage());
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
