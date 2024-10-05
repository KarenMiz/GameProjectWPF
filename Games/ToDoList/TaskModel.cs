using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameProjectWPF
{
    internal class TaskModel : INotifyPropertyChanged
    {
        private bool _isReadOnly = true;
        private bool _isDone;

        public int Id { get; set; }
        private string _description;
        public bool IsDone
        {
            get => _isDone;
            set
            {
                if (_isDone != value)
                {
                    _isDone = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(); // Notify the UI of the change
                }
            }
        }

        private DateTime _creationTime;
        public string CreationTime
        {
            get => _creationTime.ToString("dd/MM/yyyy");
            private set => _creationTime = DateTime.Parse(value);
        }

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                OnPropertyChanged(); // Notify UI of changes
            }
        }
        public bool IsInEditMode { get; set; } = false;

        public TaskModel(int id, string description)
        {
            Id = id;
            Description = description;
            IsDone = false;
            CreationTime = DateTime.Now.ToString("dd/MM/yyyy");
            IsReadOnly = true; // Task is read-only initially
        }

        public override string ToString()
        {
            return $"{Id}. {Description} - {CreationTime} - Is Done: {IsDone}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
