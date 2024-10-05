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

namespace GameProjectWPF.Games.Calculator
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private double _currentValue = 0;
        private double _storedValue = 0;
        private string _currentOperator = "";
        private bool _operatorClicked = false;
        public Calculator()
        {
            InitializeComponent();
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (_operatorClicked)
            {
                Display.Text = "";
                _operatorClicked = false;
            }
            var button = sender as System.Windows.Controls.Button;
            Display.Text += button.Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;

            // Check if Display.Text is empty or not a valid number
            if (string.IsNullOrEmpty(Display.Text) || !double.TryParse(Display.Text, out _))
            {
                MessageBox.Show("Please enter a valid number before selecting an operator.");
                return; // Exit the method if the display text is invalid
            }

            _currentOperator = button.Content.ToString();
            _storedValue = Convert.ToDouble(Display.Text);
            _operatorClicked = true;
        }


        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = Convert.ToDouble(Display.Text);

            switch (_currentOperator)
            {
                case "+":
                    _currentValue = _storedValue + _currentValue;
                    break;
                case "−":
                    _currentValue = _storedValue - _currentValue;
                    break;
                case "×":
                    _currentValue = _storedValue * _currentValue;
                    break;
                case "÷":
                    _currentValue = _storedValue / _currentValue;
                    break;
            }

            Display.Text = _currentValue.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            _storedValue = 0;
            _currentValue = 0;
            _currentOperator = "";
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains("."))
            {
                Display.Text += ".";
            }
        }

        private void Negate_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.StartsWith("-"))
            {
                Display.Text = Display.Text.Substring(1);
            }
            else
            {
                Display.Text = "-" + Display.Text;
            }
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = Convert.ToDouble(Display.Text) / 100;
            Display.Text = _currentValue.ToString();
        }
    }
}
