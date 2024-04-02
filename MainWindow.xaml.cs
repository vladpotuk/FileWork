using System;
using System.IO;
using System.Windows;

namespace FileInteraction
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReplaceWordsButton_Click(object sender, RoutedEventArgs e)
        {
            string searchWord = SearchWordTextBox.Text;
            string replaceWord = ReplaceWordTextBox.Text;

            if (string.IsNullOrEmpty(searchWord) || string.IsNullOrEmpty(replaceWord))
            {
                MessageBox.Show("Введіть слово для пошуку та слово для заміни!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string filePath = "sample.txt"; 
                string fileContent = ReadFile(filePath); 

                
                string newFileContent = ReplaceWords(fileContent, searchWord, replaceWord);

                
                SaveFile(filePath, newFileContent);

              
                int replacementsCount = CountReplacements(fileContent, searchWord);
                ShowStatistics(replacementsCount, searchWord, replaceWord, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private void SaveFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        private string ReplaceWords(string content, string searchWord, string replaceWord)
        {
            return content.Replace(searchWord, replaceWord);
        }

        private int CountReplacements(string content, string searchWord)
        {
            int count = 0;
            int index = content.IndexOf(searchWord);
            while (index != -1)
            {
                count++;
                index = content.IndexOf(searchWord, index + searchWord.Length);
            }
            return count;
        }

        private void ShowStatistics(int replacementsCount, string searchWord, string replaceWord, string filePath)
        {
            StatisticsTextBlock.Text = $"Знайдено та замінено {replacementsCount} входжень слова '{searchWord}' на слово '{replaceWord}' у файлі '{filePath}'.";
        }
    }
}
