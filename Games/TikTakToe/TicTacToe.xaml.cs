using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameProjectWPF
{
    public partial class TicTacToe : Window
    {
        private string[,] board;
        private bool playerXTurn;
        private bool gameOver;

        public TicTacToe()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            board = new string[3, 3];
            playerXTurn = true;
            gameOver = false;
            StartNewGameButton.Visibility = Visibility.Collapsed;
            ClearBoard();
            UpdateStatus("Player X's turn");
        }

        private void StatusText_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (gameOver)  // Only allow the message to disappear after the game is over
            {
                StatusText.Visibility = Visibility.Collapsed;
            }
        }

        private void ClearBoard()
        {
            Btn00.Content = "";
            Btn01.Content = "";
            Btn02.Content = "";
            Btn10.Content = "";
            Btn11.Content = "";
            Btn12.Content = "";
            Btn20.Content = "";
            Btn21.Content = "";
            Btn22.Content = "";
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver) return;

            Button cell = (Button)sender;
            int row = Grid.GetRow(cell);
            int col = Grid.GetColumn(cell);

            if (board[row, col] == null)
            {
                board[row, col] = playerXTurn ? "X" : "O";
                cell.Content = board[row, col];

                if (CheckForWinner(row, col))
                {
                    string winner = playerXTurn ? "X" : "O";
                    UpdateStatus($"Player {winner} wins!");
                    StatusText.Foreground = System.Windows.Media.Brushes.Yellow; //הוספתי
                    gameOver = true;
                    StartNewGameButton.Visibility = Visibility.Visible;
                }
                else if (CheckForDraw())
                {
                    UpdateStatus("It's a draw!");
                    gameOver = true;
                    StartNewGameButton.Visibility = Visibility.Visible;
                }
                else
                {
                    playerXTurn = !playerXTurn;
                    UpdateStatus(playerXTurn ? "Player X's turn" : "Player O's turn");
                    

                }
            }
        }

        private bool CheckForWinner(int row, int col)
        {
            string player = board[row, col];

            // Check row
            if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                return true;

            // Check column
            if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                return true;

            // Check diagonal
            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
                return true;

            return false;
        }

        private bool CheckForDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == null)
                        return false;
                }
            }
            return true;
        }

        private void UpdateStatus(string message)
        {
            StatusText.Text = message;
            StatusText.Visibility = Visibility.Visible;
           
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Foreground = System.Windows.Media.Brushes.White; 
            InitializeGame();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
