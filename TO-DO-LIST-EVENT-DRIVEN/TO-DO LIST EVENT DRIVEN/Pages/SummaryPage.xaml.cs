using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TO_DO_LIST_EVENT_DRIVEN.Pages
{
    public partial class SummaryPage : Page
    {
        private string filePath = System.IO.Path.Combine(
            System.AppDomain.CurrentDomain.BaseDirectory, "Data", "tasks.txt");

        private static int tasksCompleted = 0;

        public SummaryPage()
        {
            InitializeComponent();
            taskCompletionCount.Text = tasksCompleted.ToString(); // Load the correct count
        }



        // public static void UpdateTaskCompletion()
        public static void UpdateTaskCompletion(bool increment = true)
        {
            if (increment)
            {
                tasksCompleted++;
            }
        }

        public void RefreshTaskCount()
        {
            taskCompletionCount.Text = tasksCompleted.ToString();
        }




        private void ViewWorkTasks_Click(object sender, RoutedEventArgs e)
        {
            OpenCategoryWindow("Work");
        }

        private void ViewPersonalTasks_Click(object sender, RoutedEventArgs e)
        {
            OpenCategoryWindow("Personal");
        }

        private void ViewErrandsTasks_Click(object sender, RoutedEventArgs e)
        {
            OpenCategoryWindow("Errands");
        }

        private void OpenCategoryWindow(string category)
        {
            var tasks = File.Exists(filePath)
                ? File.ReadAllLines(filePath).Where(t => t.Contains($"Category: {category}")).ToList()
                : new System.Collections.Generic.List<string>();

            CategoryWindow categoryWindow = new CategoryWindow(category, tasks);
            categoryWindow.ShowDialog();
        }
    }
}
