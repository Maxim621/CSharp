using CSharp.Homework8.Bank;
using System;
using System.Collections.Generic;
using System.Linq;

class Film
{
    public string Name { get; set; }
    public string Director { get; set; }
}

class Director
{
    public string Name { get; set; }
    public string Country { get; set; }
}

class Program
{
    static void Main()
    {
        List<Film> films = new List<Film>()
        {
            new Film { Name = "The Silence of the Lambs", Director = "Jonathan Demme" },
            new Film { Name = "The World's Fastest Indian", Director = "Roger Donaldson" },
            new Film { Name = "The Recruit", Director = "Roger Donaldson" }
        };

        List<Director> directors = new List<Director>()
        {
            new Director {Name = "Jonathan Demme", Country = "USA"},
            new Director {Name = "Roger Donaldson", Country = "New Zealand"},
        };

        // 1. string.Join за допомогою Aggregate
        Console.WriteLine(films.Select(film => film.Name).Aggregate((film1, film2) => $"{film1}, {film2}"));

        // 2. string.Concat за допомогою Aggregate
        Console.WriteLine(films.Select(film => film.Name).Aggregate((film1, film2) => film1 + film2));

        // 3. Вивести всі фільми у такому форматі: "FilmName DirectorName (DirectorCountry)"
        Console.WriteLine(films.Select(film => $"{film.Name} {directors.First(d => d.Name == film.Director).Name} ({directors.First(d => d.Name == film.Director).Country})").Aggregate((film1, film2) => $"{film1}\n{film2}"));

        // 4. Вивести усі фільми кожного режисера через кому
        Console.WriteLine(directors.Select(director => $"{director.Name}: {string.Join(", ", films.Where(film => film.Director == director.Name).Select(film => film.Name))}").Aggregate((dir1, dir2) => $"{dir1}\n{dir2}"));

        BankMenu.Start();

    }
}