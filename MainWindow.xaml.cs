using System.IO;
using System.Windows;

namespace FileStatistics
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeFile_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text.Trim();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не існує!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string fileContent = File.ReadAllText(filePath);

            int sentenceCount = CountSentences(fileContent);
            int upperCaseCount = CountUpperCaseLetters(fileContent);
            int lowerCaseCount = CountLowerCaseLetters(fileContent);
            int vowelCount = CountVowels(fileContent);
            int consonantCount = CountConsonants(fileContent);
            int digitCount = CountDigits(fileContent);

            StatisticsTextBlock.Text = $"Кількість речень: {sentenceCount}\n" +
                                       $"Кількість великих літер: {upperCaseCount}\n" +
                                       $"Кількість маленьких літер: {lowerCaseCount}\n" +
                                       $"Кількість голосних літер: {vowelCount}\n" +
                                       $"Кількість приголосних літер: {consonantCount}\n" +
                                       $"Кількість цифр: {digitCount}";
        }

        private int CountSentences(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == '.' || c == '!' || c == '?')
                    count++;
            }
            return count;
        }

        private int CountUpperCaseLetters(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsUpper(c))
                    count++;
            }
            return count;
        }

        private int CountLowerCaseLetters(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLower(c))
                    count++;
            }
            return count;
        }

        private int CountVowels(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if ("aeiouAEIOU".Contains(c))
                    count++;
            }
            return count;
        }

        private int CountConsonants(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if ("bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(c))
                    count++;
            }
            return count;
        }

        private int CountDigits(string text)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                    count++;
            }
            return count;
        }
    }
}
