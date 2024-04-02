using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace NumberStatsAnalyzer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\path\to\your\file.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл не знайдено.");
                return;
            }

            int positiveCount = 0;
            int negativeCount = 0;
            int twoDigitCount = 0;
            int fiveDigitCount = 0;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    if (number > 0)
                        positiveCount++;
                    else if (number < 0)
                        negativeCount++;

                    if (number >= 10 && number <= 99)
                        twoDigitCount++;
                    else if (number >= -99999 && number <= -10000)
                        fiveDigitCount++;
                }
            }

            PositiveCountLabel.Content = $"Кількість додатніх чисел: {positiveCount}";
            NegativeCountLabel.Content = $"Кількість від'ємних чисел: {negativeCount}";
            TwoDigitCountLabel.Content = $"Кількість двозначних чисел: {twoDigitCount}";
            FiveDigitCountLabel.Content = $"Кількість п'ятизначних чисел: {fiveDigitCount}";

            WriteNumbersToFile(lines.Where(x => int.TryParse(x, out int num) && num > 0).ToArray(), "positive_numbers.txt");
            WriteNumbersToFile(lines.Where(x => int.TryParse(x, out int num) && num < 0).ToArray(), "negative_numbers.txt");
        }

        private void WriteNumbersToFile(string[] numbers, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            File.WriteAllLines(filePath, numbers);
        }
    }
}
