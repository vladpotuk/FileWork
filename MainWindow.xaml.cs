using System;
using System.IO;
using System.Text;
using System.Windows;

namespace ReverseFileContent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReverseContentButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Введіть шлях до файлу!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                string reversedContent = ReverseString(fileContent);

                string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "reversed_" + Path.GetFileName(filePath));
                File.WriteAllText(outputFilePath, reversedContent);

                ResultTextBlock.Text = $"Вміст файлу перевернуто та збережено у файлі '{outputFilePath}'.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
