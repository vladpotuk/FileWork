using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace RandomNumbers
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateNumbers_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int[] numbers = new int[10000];
            random.NextBytes(new byte[numbers.Length * sizeof(int)]);

            int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();
            int[] oddNumbers = numbers.Where(n => n % 2 != 0).ToArray();

            WriteToFile("evenNumbers.txt", evenNumbers);
            WriteToFile("oddNumbers.txt", oddNumbers);

            DisplayStatistics(evenNumbers.Length, oddNumbers.Length);
        }

        private void WriteToFile(string fileName, int[] numbers)
        {
            File.WriteAllLines(fileName, numbers.Select(n => n.ToString()));
        }

        private void DisplayStatistics(int evenCount, int oddCount)
        {
            StatisticsListBox.Items.Clear();
            StatisticsListBox.Items.Add($"Кількість парних чисел: {evenCount}");
            StatisticsListBox.Items.Add($"Кількість непарних чисел: {oddCount}");
        }
    }
}
