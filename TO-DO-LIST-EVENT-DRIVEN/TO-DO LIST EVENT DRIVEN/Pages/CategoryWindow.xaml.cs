using System.Collections.Generic;
using System.Windows;

namespace TO_DO_LIST_EVENT_DRIVEN.Pages
{
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(string category, List<string> tasks)
        {
            InitializeComponent();
            categoryTitle.Text = $"{category} Tasks";
            taskListBox.ItemsSource = tasks;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
