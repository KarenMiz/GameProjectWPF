using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameProjectWPF.Games.SnakeGame
{
    /// <summary>
    /// Interaction logic for SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private List<Rectangle> snakeParts = new List<Rectangle>();
        private Point snakeDirection = new Point(20, 0); // Initial movement direction (right)
        private int snakeLength = 3;
        private Rectangle food;
        private int score = 0;
        private Random rand = new Random();
        public SnakeGame()
        {
            InitializeComponent();
            gameTimer.Interval = TimeSpan.FromMilliseconds(100);
            gameTimer.Tick += GameTimer_Tick;
        }
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Collapsed;
            ResetGame();
            gameTimer.Start();
            this.KeyDown += OnKeyDown;
        }

        private void ResetGame()
        {
            snakeParts.Clear();
            GameArea.Children.Clear();

            for (int i = 0; i < snakeLength; i++)
            {
                Rectangle snakePart = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.LimeGreen,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                Canvas.SetTop(snakePart, 100);
                Canvas.SetLeft(snakePart, 100 - (i * 20));
                GameArea.Children.Add(snakePart);
                snakeParts.Add(snakePart);
            }

            score = 0;
            ScoreText.Text = score.ToString();

            // Create food
            PlaceFood();
        }

        private void PlaceFood()
        {
            food = new Rectangle
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            Canvas.SetTop(food, rand.Next(0, (int)(GameArea.Height / 20)) * 20);
            Canvas.SetLeft(food, rand.Next(0, (int)(GameArea.Width / 20)) * 20);
            GameArea.Children.Add(food);
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Move the snake
            for (int i = snakeParts.Count - 1; i > 0; i--)
            {
                Canvas.SetTop(snakeParts[i], Canvas.GetTop(snakeParts[i - 1]));
                Canvas.SetLeft(snakeParts[i], Canvas.GetLeft(snakeParts[i - 1]));
            }

            Canvas.SetTop(snakeParts[0], Canvas.GetTop(snakeParts[0]) + snakeDirection.Y);
            Canvas.SetLeft(snakeParts[0], Canvas.GetLeft(snakeParts[0]) + snakeDirection.X);

            // Check for collisions
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            // Check snake collision with food
            if (Math.Abs(Canvas.GetTop(snakeParts[0]) - Canvas.GetTop(food)) < 20 &&
                Math.Abs(Canvas.GetLeft(snakeParts[0]) - Canvas.GetLeft(food)) < 20)
            {
                score += 10;
                ScoreText.Text = score.ToString();

                GameArea.Children.Remove(food);
                Rectangle newPart = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.LimeGreen,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1
                };

                snakeParts.Add(newPart);
                GameArea.Children.Add(newPart);

                PlaceFood();
            }

            // Check for wall collisions
            if (Canvas.GetTop(snakeParts[0]) < 0 || Canvas.GetTop(snakeParts[0]) >= GameArea.Height ||
                Canvas.GetLeft(snakeParts[0]) < 0 || Canvas.GetLeft(snakeParts[0]) >= GameArea.Width)
            {
                GameOver();
            }

            // Check for self-collision
            for (int i = 1; i < snakeParts.Count; i++)
            {
                if (Math.Abs(Canvas.GetTop(snakeParts[0]) - Canvas.GetTop(snakeParts[i])) < 20 &&
                    Math.Abs(Canvas.GetLeft(snakeParts[0]) - Canvas.GetLeft(snakeParts[i])) < 20)
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Over! Your score is " + score);
            StartButton.Visibility = Visibility.Visible;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    if (snakeDirection != new Point(0, 20)) snakeDirection = new Point(0, -20);
                    break;
                case Key.Down:
                    if (snakeDirection != new Point(0, -20)) snakeDirection = new Point(0, 20);
                    break;
                case Key.Left:
                    if (snakeDirection != new Point(20, 0)) snakeDirection = new Point(-20, 0);
                    break;
                case Key.Right:
                    if (snakeDirection != new Point(-20, 0)) snakeDirection = new Point(20, 0);
                    break;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
