using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework2
{
    public class Lab2
    {
        public static void task1()
        {
            string str = "Hello, I'm Max";

            string reversedStr = ReverseString(str);
            Console.WriteLine(reversedStr);
        }
        public static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            int start = 0;
            int end = chars.Length - 1;

            while (start < end)
            {
                char temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;
                start++;
                end--;
            }

            return new string(chars);
        }

        public static void task2()
        {
            Console.Write("Enter the number: ");
            int input = int.Parse(Console.ReadLine());

            Syracuse(input);
        }

        static void Syracuse(int number)
        {
            Console.WriteLine(number);

            if (number == 1)
            {
                return;
            }
            else if (number % 2 == 0)
            {
                Syracuse(number / 2);
            }
            else
            {
                Syracuse(number * 3 + 1);
            }
        }

        public static void task3()
        {
            Console.WriteLine("Invalid words: wo214rd1, w15rd2 and wo1347rd3.");
            string input = "This is the corrected text: c#, wo214rd1, is: the! w15rd2; wo1347rd3? best.";
            string[] forbiddenWords = { "wo214rd1", "w15rd2", "wo1347rd3" };

            string[] words = input.Split(' ', ',', '.', ':', ';', '!', '?');

            List<string> filteredWords = new List<string>();

            foreach (string word in words)
            {
                if (!forbiddenWords.Contains(word))
                {
                    filteredWords.Add(word);
                }
            }

            string filteredText = string.Join(" ", filteredWords);

            Console.WriteLine(filteredText);
        }

        public static void task4()
        {
            int length = 10;
            string availableCharacters = "abcdefghijklmnopqrstuvwxyz1234567890";

            string randomString = GenerateRandomString(length, availableCharacters);
            Console.WriteLine(randomString);
        }

        private static Random random = new Random();

        static string GenerateRandomString(int length, string characters)
        {
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(characters.Length);
                chars[i] = characters[randomIndex];
            }

            return new string(chars);
        }

        public static void task5()
        {
            int[] array = { 7, 2, 4, 8, 3, 5, 0, 1, 9 };

            int n = array.Length;
            int expectedSum = (n * (n + 1)) / 2;
            int actualSum = 0;

            for (int i = 0; i < n; i++)
            {
                actualSum += array[i];
            }

            int missingNumber = expectedSum - actualSum;

            Console.WriteLine("Hole in the array: " + missingNumber);
        }

        static int width = 10;
        static int height = 10;
        static bool[,] grid = new bool[width, height];
        static bool[,] nextGeneration = new bool[width, height];

        //---------------------------------------------------------------------------------------------------------
        public static void GameLive()
        {
            // Заповнюємо початкову конфігурацію "живими" клітинами
            InitializeGrid();

            // Головний цикл ігор
            while (true)
            {
                PrintGrid();
                CalculateNextGeneration();
                if (IsGameOver())
                {
                    Console.WriteLine("Игра завершена.");
                    break;
                }
                Console.ReadLine(); // Додано для паузи між поколіннями (натисніть Enter, щоб перейти до наступного покоління)
            }
        }

        static void InitializeGrid()
        {

            // Вручну розставляємо "живі" клітини в початковій конфігурації

            grid[1, 4] = true;
            grid[2, 3] = true;
            grid[5, 1] = true;
            grid[7, 6] = true;

            // або рандомно
            //Random random = new Random();

            //for (int y = 0; y < height; y++)
            //{
            //for (int x = 0; x < width; x++)
            //{
            // grid[x, y] = (random.Next(2) == 0);
            // }
            // }
        }

        static void PrintGrid()
        {
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y])
                        Console.Write("X");
                    else
                        Console.Write("1");
                }
                Console.WriteLine();
            }
        }

        static void CalculateNextGeneration()
        {
            // Код для розрахунку наступного покоління платформи гри

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int liveNeighbors = CountLiveNeighbors(x, y); // Підраховуємо кількість "живих" сусідів поточної клітини

                    // Применяем правила игры
                    if (grid[x, y])
                    {
                        if (liveNeighbors == 2 || liveNeighbors == 3)
                            nextGeneration[x, y] = true; // Клітина продовжує жити
                        else
                            nextGeneration[x, y] = false; // Клітина вмирає
                    }
                    else // Поточна клітка "мертва"
                    {
                        if (liveNeighbors == 3)
                            nextGeneration[x, y] = true; // Клітина оживає
                        else
                            nextGeneration[x, y] = false; // Клітина залишається мертвою
                    }
                }
            }

            // Обновляем состояние площадки игры на основе рассчитанного следующего поколения
            Array.Copy(nextGeneration, grid, nextGeneration.Length);
        }

        static int CountLiveNeighbors(int x, int y)
        {
            int liveNeighbors = 0;

            // Перевіряємо стан усіх восьми сусідніх клітин
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = x + i;
                    int neighborY = y + j;

                    // Перевіряємо, що сусідні клітини в межах майданчика гри
                    if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                    {
                        if (grid[neighborX, neighborY])
                            liveNeighbors++;
                    }
                }
            }

            return liveNeighbors;
        }

        static bool IsGameOver()
        {
            // Перевіряємо умову завершення гри: відсутність «живих» клітин на майданчику
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y])
                        return false; // Знайдена "жива" клітина, гра продовжується
                }
            }

            return true; // Всі клітини мертві, гра завершена
        }

        //---------------------------------------------------------------------------------------------------------

        public static void task7()
        {
            string input = "AAACCCGGGGGTTTT";
            Console.WriteLine("Input: " + input);

            // Стиснення
            string compressed = Lab2.Compress(input);
            Console.WriteLine("Compressed: " + compressed);

            // Декомпресія
            string decompressed = Lab2.Decompress(compressed);
            Console.WriteLine("Decompressed: " + decompressed);
        }

        public static string Compress(string input)
        {
            List<byte> compressedResult = new List<byte>();

            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > 2)
                    {
                        compressedResult.Add((byte)count);
                        compressedResult.Add(GetNucleotideCode(input[i - 1]));
                    }
                    else
                    {
                        for (int j = 0; j < count; j++)
                        {
                            compressedResult.Add(GetNucleotideCode(input[i - 1]));
                        }
                    }

                    count = 1;
                }
            }

            // Додати останній символ та його повторення
            if (count > 2)
            {
                compressedResult.Add((byte)count);
                compressedResult.Add(GetNucleotideCode(input[input.Length - 1]));
            }
            else
            {
                for (int j = 0; j < count; j++)
                {
                    compressedResult.Add(GetNucleotideCode(input[input.Length - 1]));
                }
            }

            return Convert.ToBase64String(compressedResult.ToArray());
        }

        public static string Decompress(string input)
        {
            byte[] compressedData = Convert.FromBase64String(input);
            List<char> decompressedResult = new List<char>();

            for (int i = 0; i < compressedData.Length; i += 2)
            {
                int count = compressedData[i];
                char symbol = GetNucleotideFromCode(compressedData[i + 1]);

                for (int j = 0; j < count; j++)
                {
                    decompressedResult.Add(symbol);
                }
            }

            return new string(decompressedResult.ToArray());
        }

        private static byte GetNucleotideCode(char nucleotide)
        {
            switch (nucleotide)
            {
                case 'A':
                    return 0;
                case 'C':
                    return 1;
                case 'G':
                    return 2;
                case 'T':
                    return 3;
                default:
                    throw new ArgumentException("Invalid nucleotide: " + nucleotide);
            }
        }

        private static char GetNucleotideFromCode(byte code)
        {
            switch (code)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'C';
                case 2:
                    return 'G';
                case 3:
                    return 'T';
                default:
                    throw new ArgumentException("Invalid nucleotide code: " + code);
            }
        }

        //---------------------------------------------------------------------------------

        public static void task8()
        {
            string plainText = "Secret information";

            byte[] key = Lab2.GenerateRandomKey(16);

            string encryptedText = Lab2.EncryptString(plainText, key);
            Console.WriteLine("Зашифрований текст: " + encryptedText);

            string decryptedText = Lab2.DecryptString(encryptedText, key);
            Console.WriteLine("Дешифрований текст: " + decryptedText);
        }

        private static byte[] GenerateRandomKey(int length)
        {
            byte[] key = new byte[length];
            Random random = new Random();
            random.NextBytes(key);
            return key;
        }

        public static string EncryptString(string plainText, byte[] key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = new byte[plainBytes.Length];

            for (int i = 0; i < plainBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(plainBytes[i] ^ key[i % key.Length]);
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptString(string encryptedText, byte[] key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedBytes = new byte[encryptedBytes.Length];

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedBytes[i] ^ key[i % key.Length]);
            }

            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedText;
        }
    }
}
