using GameProjectWPF.Games.SnakeGame;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
        }

        private void btn1(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "A classic strategy game where two players, X and O, take turns marking spaces on a 3x3 grid. The goal is to be the first to align three of your marks horizontally, vertically, or diagonally. Test your skills and challenge your opponent in this timeless game!",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",
                LargeImagePath = "/Images/tic-tac-toe.png",
                GameType = "TicTacToe"
            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();
        }

        private void btn2(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "In this action-packed game, your mission is to shoot as many enemies as possible to score points. The more enemies you defeat, the higher your score, allowing you to advance to the next level. Each level brings new challenges, making you test your shooting skills to survive and progress further!",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",               
                LargeImagePath = "/Images/battle shooter.png",
                GameType = "BattleShooter"
            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();
        }

        private void btn3(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "Discover everything you need to know about each country around the globe. This page provides detailed information using real-time data from an API, including population, capital, languages, region, and much more. Explore the world at your fingertips and get insights on all the countries with up-to-date facts and statistics.",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",
                ImagePathSmall3 = "/Images/technologies/api.png",
                LargeImagePath = "/Images/planet earth.png",
                GameType = "planetEarth"
            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();
        }

        private void btn4(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "This project allows users to efficiently manage tasks by adding, editing, and deleting them. The interface includes a dedicated page where tasks can be created and managed. All tasks are stored in a JSON file, ensuring persistence and easy retrieval across sessions.",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",
                ImagePathSmall3 = "/Images/technologies/json.png",
                LargeImagePath = "/Images/to-do-list-img.jpg",
                GameType = "ToDoList"

            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();
        }

        private void btn5(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "Control a growing snake as it moves across the screen, eating food to gain points and grow longer. Be careful not to hit the walls or your own tail, as the game speeds up and the challenge increases. How long can you keep the snake alive?",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",

                LargeImagePath = "/Images/SnakeIMG.jpg",
                GameType = "SnakeGame"

            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();

        }

        private void btn6(object sender, RoutedEventArgs e)
        {
            var viewModel = new GameViewModel
            {
                Description = "A simple and user-friendly calculator designed for basic arithmetic operations like addition, subtraction, multiplication, and division. Perfect for quick calculations and everyday use, featuring a clear display and easy-to-use interface.",
                ImagePathSmall1 = "/Images/technologies/oop.png",
                ImagePathSmall2 = "/Images/technologies/c.png",

                LargeImagePath = "/Images/Calculator_IMG.png",
                GameType = "Calculator"

            };
            var gamePage = new GameExplanationPage(viewModel);
            gamePage.Show();
        }

        // Repeat for other games...



    }
}