using System.Windows;
using System.Windows.Controls;

namespace WpfButtonGrid
{
    public partial class MainWindow : Window
    {
        private int currentButtonNumber = 1;
        private int overrideIndex = 0;

        public delegate void ButtonClickedHandler(int number);
        public event ButtonClickedHandler OnAnyButtonClicked;

        public MainWindow()
        {
            InitializeComponent();
            OnAnyButtonClicked += ShowButtonClickedMessage;

            AddButton.Click += (s, e) =>
            {
                OnAnyButtonClicked?.Invoke(0);
                AddButtonLogic();
            };
        }

        private void AddButtonLogic()
        {
            int totalButtons = ButtonGrid.Children.Count;
            if (totalButtons < 15)
            {
                AddNewButton(currentButtonNumber++);
            }
            else
            {
                var result = MessageBox.Show(
                    "Maximum number of buttons reached. Override the oldest button?",
                    "Max Buttons",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    ReplaceOldestButton();
                }
            }
        }

        private void AddNewButton(int buttonNumber)
        {
            int n = ButtonGrid.Children.Count;
            int col = n / 5;
            int row = n % 5;

            var btn = new Button
            {
                Content = $"Button {buttonNumber}",
                Margin = new Thickness(5),
                Height = 100,
                Width = 240
            };
            btn.Click += (s, e) => OnAnyButtonClicked?.Invoke(buttonNumber);

            Grid.SetRow(btn, row);
            Grid.SetColumn(btn, col);
            ButtonGrid.Children.Add(btn);
        }

        private void ReplaceOldestButton()
        {
            int col = overrideIndex / 5;
            int row = overrideIndex % 5;

            Button btnToReplace = null;
            foreach (UIElement el in ButtonGrid.Children)
            {
                if (Grid.GetRow(el) == row && Grid.GetColumn(el) == col)
                {
                    btnToReplace = el as Button;
                    break;
                }
            }

            if (btnToReplace != null)
            {
                ButtonGrid.Children.Remove(btnToReplace);
            }

            // Create new button for this spot
            var newBtn = new Button
            {
                Content = $"Button {currentButtonNumber}",
                Margin = new Thickness(5),
                Height = 100,
                Width = 240
            };
            newBtn.Click += (s, e) => OnAnyButtonClicked?.Invoke(currentButtonNumber);

            Grid.SetRow(newBtn, row);
            Grid.SetColumn(newBtn, col);
            ButtonGrid.Children.Add(newBtn);

            overrideIndex = (overrideIndex + 1) % 15;
            currentButtonNumber++;
        }

        private void ShowButtonClickedMessage(int number)
        {
            if (number == 0)
                MessageBox.Show("Add Button clicked!");
            else
                MessageBox.Show($"Button {number} clicked!");
        }
    }
}
