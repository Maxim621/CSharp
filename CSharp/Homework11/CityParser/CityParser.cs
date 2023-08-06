using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.Homework11.CityParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CityParser <inputFilePath> <outputFilePath>");
                return;
            }

            string inputFilePath = args[0];
            string outputFilePath = args[1];

            List<string> citiesData = ParseCitiesFromFile(inputFilePath);
            WriteCitiesToFile(citiesData, outputFilePath);

            Console.WriteLine($"Parsed {citiesData.Count} cities and saved to {outputFilePath}.");
        }

        static List<string> ParseCitiesFromFile(string inputFilePath)
        {
            List<string> citiesData = new List<string>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    citiesData.Add(line);
                }
            }

            return citiesData;
        }

        static void WriteCitiesToFile(List<string> citiesData, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var cityData in citiesData)
                {
                    writer.WriteLine(cityData);
                }
            }
        }
    }
}
