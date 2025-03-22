using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TO_DO_LIST_EVENT_DRIVEN.Pages
{
    public partial class TaskPage : Page
    {
        private string filePath = System.IO.Path.Combine(
            System.AppDomain.CurrentDomain.BaseDirectory, "Data", "tasks.txt");

        public class TaskItem
        {
            public string TaskName { get; set; }
            public string Priority { get; set; }
            public string Category { get; set; }
            public string Deadline { get; set; }
        }

        public TaskPage()
        {
            InitializeComponent();
            EnsureDataDirectoryExists();
            LoadTasks();
        }

        private void EnsureDataDirectoryExists()
        {
            string dataDirectory = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory, "Data");

            if (!Directory.Exists(dataDirectory))
            {
                Directory.CreateDirectory(dataDirectory);
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string task = taskNameTextBox.Text;
            string priority = (priorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string category = (categoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string deadline = DeadlineDatePicker.SelectedDate?.ToString("yyyy-MM-dd") ?? "No Deadline";

            if (!string.IsNullOrEmpty(task) && !string.IsNullOrEmpty(priority) && !string.IsNullOrEmpty(category))
            {
                string taskEntry = $"{task} | Priority: {priority} | Category: {category} | Deadline: {deadline}";
                File.AppendAllText(filePath, taskEntry + "\n");
                taskListBox.Items.Add(taskEntry);
                taskNameTextBox.Clear();
                priorityComboBox.SelectedIndex = -1;
                categoryComboBox.SelectedIndex = -1;
                DeadlineDatePicker.SelectedDate = null;
            }

            if (string.IsNullOrEmpty(task))
            {
                MessageBox.Show("Please enter a task first");
            }
        }


        private void LoadTasks()
        {
            taskListBox.Items.Clear();
            if (File.Exists(filePath))
            {
                var tasks = File.ReadAllLines(filePath);
                foreach (var task in tasks)
                {
                    taskListBox.Items.Add(task);
                }
            }
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (taskListBox.SelectedItem != null)
            {
                string completedTask = taskListBox.SelectedItem.ToString();
                var tasks = File.ReadAllLines(filePath).Where(t => t != completedTask).ToList();
                File.WriteAllLines(filePath, tasks);
                taskListBox.Items.Remove(taskListBox.SelectedItem);

                // Only increment task count when a task is marked as completed
                SummaryPage.UpdateTaskCompletion(true);
            }
        }

    }
}


