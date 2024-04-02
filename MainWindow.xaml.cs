using System;
using System.IO;
using System.Windows;

namespace ModeratorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModerateButton_Click(object sender, RoutedEventArgs e)
        {
            string textFilePath = TextFilePathTextBox.Text;
            string moderationFilePath = ModerationWordsFilePathTextBox.Text;

            if (string.IsNullOrEmpty(textFilePath) || string.IsNullOrEmpty(moderationFilePath))
            {
                MessageBox.Show("Введіть шлях до файлу з текстом та файлу зі словами для модерації!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string[] moderationWords = File.ReadAllLines(moderationFilePath);

                string text = File.ReadAllText(textFilePath);

                foreach (string word in moderationWords)
                {
                    text = text.Replace(word, new string('*', word.Length));
                }

                File.WriteAllText(textFilePath, text);

                ResultTextBlock.Text = "Модерація завершена. Перевірте змінений файл.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
