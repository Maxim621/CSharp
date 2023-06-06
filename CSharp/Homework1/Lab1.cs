using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework1
{
    public class Lab1
    {
        static void Start(string[] args)
        {
            task1();

            task2();

            task3();

            task4();

            task5();
        }

        static void task1()
        {
            Console.Write("Enter symbols: ");
            string input = Console.ReadLine();

            foreach (char letter in input)
            {
                int lowercaseA = (int)'a';
                int uppercaseA = (int)'A';

                // Знаходимо позицію літери в алфавіті
                int position = (int)char.ToLower(letter) - lowercaseA + 1;

                // Перекладаємо букву на інший регістр
                char convertedLetter;
                if (char.IsLower(letter))
                {
                    convertedLetter = (char)((int)letter - lowercaseA + uppercaseA);
                }
                else
                {
                    convertedLetter = (char)((int)letter - uppercaseA + lowercaseA);
                }

                Console.WriteLine("Character: {0} Alphabetical position: {1} Letters in other case: {2}", letter, position, convertedLetter);
                Console.ReadLine();
            }
        }

        static void task2()
        {
            string input = "London, Paris, Rome";
            char delimiter = ',';

            List<string> substrings = new List<string>();
            int start = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == delimiter)
                {
                    string substring = input.Substring(start, i - start);
                    substrings.Add(substring.Trim());
                    start = i + 1;
                }
            }

            // Додаємо останній підряд після останнього роздільника
            string lastSubstring = input.Substring(start);
            substrings.Add(lastSubstring.Trim());

            foreach (string substring in substrings)
            {
                Console.WriteLine(substring);
            }
        }

        static void task3()
        {
            Console.WriteLine("Enter the string:");
            string mainString = Console.ReadLine();

            Console.WriteLine("Enter a substring to search for:");
            string subString = Console.ReadLine();

            bool containsSubstring = CheckSubstring(mainString, subString);
            if (containsSubstring)
            {
                Console.WriteLine("Substring found in string.");
            }
            else
            {
                Console.WriteLine("Substring not found in string.");
            }
        }
        static bool CheckSubstring(string mainString, string subString)
        {
            int mainLength = mainString.Length;
            int subLength = subString.Length;

            for (int i = 0; i <= mainLength - subLength; i++)
            {
                int j;
                for (j = 0; j < subLength; j++)
                {
                    if (mainString[i + j] != subString[j])
                    {
                        break;
                    }
                }

                if (j == subLength)
                {
                    return true;
                }
            }

            return false;
        }


        static string[] units = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        static string[] tens = { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        static string[] hundreds = { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        static void task4()
        {
            int number = 117;
            string words = NumberToWords(number);
            Console.WriteLine($"{number} - {words}");
        }

        static string NumberToWords(int number)
        {
            if (number == 0)
            {
                return "ноль";
            }

            // Розбиваємо число на окремі розряди
            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            string result = "";

            if (digit1 != 0)
            {
                result += hundreds[digit1] + " ";
            }
            if (digit2 != 0)
            {
                if (digit2 == 1)
                {
                    result += units[digit2 * 10 + digit3] + " ";
                }
                else
                {
                    result += tens[digit2] + " ";
                }
            }
            if (digit3 != 0 && digit2 != 1)
            {
                result += units[digit3] + " ";
            }

            return result.Trim();
        }

        static void task5()
        {
            int a = 5;
            int b = 10;

            a = a ^ b;
            b = a ^ b;
            a = a ^ b;

            Console.WriteLine("a = " + a); // Виводить 10
            Console.WriteLine("b = " + b); // Виводить 5
        }
    }
}
