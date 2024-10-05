using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GameProjectWPF
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private string _description;
        private string _imagePathSmall1;
        private string _imagePathSmall2;
        private string _imagePathSmall3;
        private string _imagePathSmall4;
        private string _largeImagePath;
        public string GameType { get; set; }
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string ImagePathSmall1
        {
            get => _imagePathSmall1;
            set
            {
                _imagePathSmall1 = value;
                OnPropertyChanged();
            }
        }

        public string ImagePathSmall2
        {
            get => _imagePathSmall2;
            set
            {
                _imagePathSmall2 = value;
                OnPropertyChanged();
            }
        }

        public string ImagePathSmall3
        {
            get => _imagePathSmall3;
            set
            {
                _imagePathSmall3 = value;
                OnPropertyChanged();
            }
        }

        public string ImagePathSmall4
        {
            get => _imagePathSmall4;
            set
            {
                _imagePathSmall4 = value;
                OnPropertyChanged();
            }
        }

        public string LargeImagePath
        {
            get => _largeImagePath;
            set
            {
                _largeImagePath = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
