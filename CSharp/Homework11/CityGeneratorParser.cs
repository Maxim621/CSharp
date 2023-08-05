using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;

namespace CSharp.Homework11
{
    public record City(string Name, string Country, string Region, double Area, int Population);

    public class CityGeneratorParser
    {
        static readonly string CitiesDataFile = "cities.txt";

        public static void Start()
        {
            Console.WriteLine("Choose action: generate or parse");
            string command = Console.ReadLine();

            List<City> cities;

            switch (command.ToLower())
            {
                case "generate":
                    int numberOfRows = 100000;
                    List<string> citiesData = File.ReadAllLines(CitiesDataFile).ToList();
                    cities = GenerateCities(citiesData, numberOfRows);
                    break;
                case "parse":
                    Console.WriteLine("Enter input file path:");
                    string inputFilePath = Console.ReadLine();
                    cities = ParseCitiesFromCsv(inputFilePath);
                    break;
                default:
                    Console.WriteLine("Invalid command. Use 'generate' or 'parse'.");
                    return;
            }

            Console.WriteLine("Enter output file path:");
            string outputFilePath = Console.ReadLine();

            WriteCitiesToJson(cities, outputFilePath);

            Console.WriteLine($"Completed {command} and saved results to {outputFilePath}.");
        }

        static List<City> GenerateCities(List<string> citiesData, int numberOfRows)
        {
            Random random = new Random();
            List<City> cities = new List<City>();

            for (int i = 0; i < numberOfRows; i++)
            {
                string city = citiesData[random.Next(citiesData.Count)];
                string country = citiesData[random.Next(citiesData.Count)];
                string region = citiesData[random.Next(citiesData.Count)];
                double area = random.Next(100, 1000) + random.NextDouble();
                int population = random.Next(1000, 1000000);

                cities.Add(new City(city, country, region, area, population));
            }

            return cities;
        }

        static List<City> ParseCitiesFromCsv(string inputFilePath)
        {
            List<City> cities = new List<City>();

            using (StreamReader streamReader = new StreamReader(inputFilePath))
            using (CsvReader csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                cities = csvReader.GetRecords<City>().ToList();
            }

            return cities;
        }

        static void WriteCitiesToJson(List<City> cities, string outputFilePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(outputFilePath))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, cities);
            }
        }
    }
}
