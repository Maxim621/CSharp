using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.Homework11.CityParser
{
    public class City
    {
        public string Name { get; set; }
    }

    public class Region
    {
        public string Name { get; set; }
        public IList<City> Cities { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
        public IList<Region> Regions { get; set; }
    }

    class Program
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

            List<Country> countries = ParseCitiesFromFile(inputFilePath);
            WriteCitiesToFile(countries, outputFilePath);

            Console.WriteLine($"Parsed {countries.Count} countries and saved to {outputFilePath}.");
        }

        static List<Country> ParseCitiesFromFile(string inputFilePath)
        {
            Dictionary<string, Country> countries = new Dictionary<string, Country>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue; // Skip empty lines

                    string[] parts = line.Split(':');
                    string[] data = parts[1].Split(';');
                    string cityName = parts[0];
                    double cityArea = double.Parse(data[0]);
                    int cityPopulation = int.Parse(data[1]);
                    string countryName = data[2].Substring(0, data[2].IndexOf('('));
                    string regionName = data[2].Substring(data[2].IndexOf('(') + 1, data[2].IndexOf(')') - data[2].IndexOf('(') - 1);

                    if (!countries.ContainsKey(countryName))
                    {
                        countries[countryName] = new Country
                        {
                            Name = countryName,
                            Regions = new List<Region>()
                        };
                    }

                    Country country = countries[countryName];
                    Region region = country.Regions.FirstOrDefault(r => r.Name == regionName);
                    if (region == null)
                    {
                        region = new Region
                        {
                            Name = regionName,
                            Cities = new List<City>()
                        };
                        country.Regions.Add(region);
                    }

                    region.Cities.Add(new City { Name = cityName });
                }
            }

            return new List<Country>(countries.Values);
        }

        static void WriteCitiesToFile(List<Country> countries, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("[");

                for (int i = 0; i < countries.Count; i++)
                {
                    Country country = countries[i];
                    writer.WriteLine("{");
                    writer.WriteLine($"\"Name\": \"{country.Name}\",");
                    writer.WriteLine("\"Regions\": [");

                    for (int j = 0; j < country.Regions.Count; j++)
                    {
                        Region region = country.Regions[j];
                        writer.WriteLine("{");
                        writer.WriteLine($"\"Name\": \"{region.Name}\",");
                        writer.WriteLine("\"Cities\": [");

                        for (int k = 0; k < region.Cities.Count; k++)
                        {
                            City city = region.Cities[k];
                            writer.WriteLine($"{{ \"Name\": \"{city.Name}\" }}{(k < region.Cities.Count - 1 ? "," : "")}");
                        }

                        writer.WriteLine("]" + (j < country.Regions.Count - 1 ? "," : ""));
                        writer.WriteLine("}");
                    }

                    writer.WriteLine("]" + (i < countries.Count - 1 ? "," : ""));
                    writer.WriteLine("}");
                }

                writer.WriteLine("]");
            }
        }
    }
}