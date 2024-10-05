using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;

namespace GameProjectWPF
{
   
        internal class TaskManagerService : INotifyPropertyChanged
        {
           public string FilePath = "My to-do list.json";
           public ObservableCollection<TaskModel> Tasks { get; set; }
           private static int _idCounter = 1;

        public TaskManagerService()
            {
                Tasks = new ObservableCollection<TaskModel>();
                LoadTasksFromJson(FilePath);
            }

            public void AddTsk(TaskModel task)
            {
            task.Id = _idCounter++; // Assign the current counter value and increment
            Tasks.Add(task);
            OnPropertyChanged(nameof(Tasks));
            SaveTasksToJson(FilePath); // Save after add
             }

            public void RemoveTask(TaskModel task)
            {
                Tasks.Remove(task);
                SaveTasksToJson(FilePath);
            }

            public void UpdateTask(int taskId, string newDescription)
            {
                TaskModel task = Tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.Description = newDescription;
                    SaveTasksToJson(FilePath);
                }
                else
                {
                    throw new Exception("The task with this Id does not exist");
                }
            }


        public void ToggleTaskIsComplete(int taskId)
            {
                TaskModel task = Tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.IsDone = !task.IsDone;
                    SaveTasksToJson(FilePath);
                }
                else
                {
                    throw new Exception("The task with this Id does not exist");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void SaveTasksToJson(string filePath)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Tasks.ToList(), options);
                File.WriteAllText(filePath, jsonString);
            }

      
        public void LoadTasksFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                var tasks = JsonSerializer.Deserialize<List<TaskModel>>(jsonString);
                if (tasks != null)
                {
                    Tasks.Clear(); // Clear existing tasks to avoid duplicates
                    foreach (var task in tasks)
                    {
                        Tasks.Add(task);
                        if (task.Id >= _idCounter)
                        {
                            _idCounter = task.Id + 1; // Update counter to be unique
                        }
                    }
                    OnPropertyChanged(nameof(Tasks));
                }
            }
        }

    }

}
