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

        private void GenerateNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            // Генеруємо 100 випадкових чисел
            Random random = new Random();
            int[] numbers = new int[100];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1000); // Генеруємо випадкові числа в діапазоні від 1 до 1000
            }

            // Знаходимо прості числа та числа Фібоначчі
            string primes = "";
            string fibonacci = "";
            foreach (int number in numbers)
            {
                if (IsPrime(number))
                {
                    primes += number + Environment.NewLine;
                }
                if (IsFibonacci(number))
                {
                    fibonacci += number + Environment.NewLine;
                }
            }

            // Зберігаємо прості числа у файл
            string primesFilePath = "primes.txt";
            File.WriteAllText(primesFilePath, primes);

            // Зберігаємо числа Фібоначчі у файл
            string fibonacciFilePath = "fibonacci.txt";
            File.WriteAllText(fibonacciFilePath, fibonacci);

            // Виводимо статистику на екран
            StatisticsTextBlock.Text = $"Згенеровано 100 чисел.\n" +
                                       $"Прості числа збережено у файл {primesFilePath}.\n" +
                                       $"Числа Фібоначчі збережено у файл {fibonacciFilePath}.";
        }

        // Метод для перевірки, чи число є простим
        private bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        // Метод для перевірки, чи число є числом Фібоначчі
        private bool IsFibonacci(int number)
        {
            int a = 0;
            int b = 1;
            while (b < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == number;
        }
    }
}
