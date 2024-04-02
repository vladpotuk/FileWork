using System;
using System.IO;
using System.Windows;

namespace FileSearch
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            string filePath = "example.txt";
            string fileContent = File.ReadAllText(filePath);

            //
            bool isWordFound = fileContent.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0;
            if (isWordFound)
                ResultTextBlock.Text = $"Слово '{searchText}' знайдено.";
            else
                ResultTextBlock.Text = $"Слово '{searchText}' не знайдено.";

           
            int wordCount = CountOccurrences(fileContent, searchText, StringComparison.OrdinalIgnoreCase);
            ResultTextBlock.Text += $"\nКількість входжень слова '{searchText}': {wordCount}";

            
            string reversedSearchText = ReverseString(searchText);
            int reversedWordCount = CountOccurrences(fileContent, reversedSearchText, StringComparison.OrdinalIgnoreCase);
            ResultTextBlock.Text += $"\nКількість входжень слова '{reversedSearchText}' у зворотному порядку: {reversedWordCount}";
        }

        private int CountOccurrences(string source, string search, StringComparison comparison)
        {
            int count = 0;
            int index = source.IndexOf(search, comparison);
            while (index != -1)
            {
                count++;
                index = source.IndexOf(search, index + search.Length, comparison);
            }
            return count;
        }

        private string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
