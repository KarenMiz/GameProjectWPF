using GameProjectWPF.Games.Calculator;
using GameProjectWPF.Games.SnakeGame;
using System.Windows;
using System.Windows.Controls;

namespace GameProjectWPF
{
    public partial class GameExplanationPage : Window
    {
        private GameViewModel _viewModel;

        public GameExplanationPage(GameViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            _viewModel = viewModel;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            if (mainWindow == null)
            {
                mainWindow = new MainWindow();
                mainWindow.Show();
            }

            this.Close();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Determine which game to start based on the ViewModel or some other logic
            // For example, you can use a property or method to identify the game
            if (_viewModel != null)
            {
                // Replace this with your actual game opening logic
                // For example:
                switch (_viewModel.GameType)
                {
                    case "TicTacToe":
                        TicTacToe ticTacToe = new TicTacToe();
                        ticTacToe.Show();
                        break;
                    case "BattleShooter":
                        BattleShooterGame battleShooterGame = new BattleShooterGame();
                        battleShooterGame.Show();
                        break;
                    case "planetEarth":
                        CountriesData countriesData = new CountriesData();
                        countriesData.Show();
                        break;
                    case "ToDoList":
                        ToDoListProgram toDoListProgram = new ToDoListProgram();
                        toDoListProgram.Show();
                        break;
                    case "SnakeGame":
                        SnakeGame snakeGame = new SnakeGame();
                        snakeGame.Show();
                        break;
                    case "Calculator":
                        Calculator calculator = new Calculator();
                        calculator.Show();
                        break;
                    default:
                        MessageBox.Show("Unknown game type.");
                        break;
                }
                this.Close();
            }
        }
    }
}
