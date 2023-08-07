using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Homework11.CityGenerator
{
    class Program
    {
        static readonly string CitiesDataFile = "cities.txt";

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CityGenerator <outputFilePath> <numberOfRows>");
                return;
            }

            string outputFilePath = args[0];
            int numberOfRows = int.Parse(args[1]);

            List<string> citiesData = File.ReadAllLines(CitiesDataFile).ToList();

            GenerateCitiesAndSaveToFile(citiesData, outputFilePath, numberOfRows);

            Console.WriteLine($"Generated {numberOfRows} rows and saved to {outputFilePath}.");
        }

        static void GenerateCitiesAndSaveToFile(List<string> citiesData, string outputFilePath, int numberOfRows)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    string city = citiesData[random.Next(citiesData.Count)];
                    string country = citiesData[random.Next(citiesData.Count)];
                    string region = citiesData[random.Next(citiesData.Count)];
                    double area = random.Next(100, 1000) + random.NextDouble();
                    int population = random.Next(1000, 1000000);

                    string line = $"{city}:{area:F2};{population};{country}({region})";
                    writer.WriteLine(line);
                }
            }
        }
    }
}