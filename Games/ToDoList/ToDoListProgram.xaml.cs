using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameProjectWPF
{
    public partial class ToDoListProgram : Window
    {
        private TaskManagerService _taskManagerService;
        private TaskModel _selectedTask;

        public ToDoListProgram()
        {
            InitializeComponent();
            _taskManagerService = new TaskManagerService();
            this.DataContext = _taskManagerService;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string taskDescription = NewTaskDescription.Text;
            if (!string.IsNullOrWhiteSpace(taskDescription))
            {
                var newTask = new TaskModel(_taskManagerService.Tasks.Count + 1, taskDescription);
                _taskManagerService.AddTsk(newTask);
                NewTaskDescription.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a task description.");
            }
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button?.DataContext as TaskModel;

            if (task != null)
            {
                // Enable editing of the task description
                task.IsReadOnly = false; // Make the TextBox editable

                // Save the current task for later updating
                _selectedTask = task;
            }
        }



        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTask != null)
            {
              

                try
                {
                    _taskManagerService.UpdateTask(_selectedTask.Id, _selectedTask.Description);
                    _selectedTask.IsReadOnly = true; // Make the TextBox non-editable again

                    // No need to call OnPropertyChanged for Tasks here
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }






        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button?.DataContext as TaskModel;

            if (task != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete the task?", "Delete Task", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    _taskManagerService.RemoveTask(task);
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            var task = checkbox?.DataContext as TaskModel;

            if (task != null)
            {
                // Update the task status based on the checkbox state
                _taskManagerService.ToggleTaskIsComplete(task.Id);
                // Notify the change in the checkbox state
                task.IsDone = !task.IsDone;
            }
        }

        private void NewTaskDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddTask_Click(sender, e);
            }
        }
    }

}