using CSharp.Homework7;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var data = new List<object>() {
      "Hello",
      new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
      new List<int>() {4, 6, 8, 2},
      new string[] {"Hello inside array"},
      new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
        new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
        new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
      }},
      new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
        new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
      }},
      new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
      "Leonardo DiCaprio"
    };

        // Завдання 1
        Console.WriteLine(string.Join(", ", data.Where(item => item is not ArtObject)));

        // Завдання 2
        Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(film => film.Actors).Select(actor => actor.Name).Distinct()));

        // Завдання 3
        Console.WriteLine(data.OfType<Film>().SelectMany(film => film.Actors).Where(actor => actor.Birthdate.Month == 8).Select(actor => actor.Name).Distinct().Count());

        // Завдання 4
        Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(film => film.Actors).OrderBy(actor => actor.Birthdate).Take(2).Select(actor => actor.Name)));

        // Завдання 5
        Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"{group.Key}: {group.Count()}")));

        // Завдання 6
        Console.WriteLine($"Books per author: {data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"{group.Key}: {group.Count()}").FirstOrDefault()} \n" +
                  $"Films per director: {data.OfType<Film>().GroupBy(film => film.Author).Select(group => $"{group.Key}: {group.Count()}").FirstOrDefault()}");

        // Завдання 7
        Console.WriteLine(data.OfType<Film>().SelectMany(film => film.Actors).SelectMany(actor => actor.Name.ToLower()).Distinct().Count());

        // Завдання 8
        Console.WriteLine(string.Join(", ", data.OfType<Book>().OrderBy(book => book.Author).ThenBy(book => book.Pages).Select(book => $"{book.Name} ({book.Author}): {book.Pages} pages")));

        // Завдання 9
        Console.WriteLine(string.Join("\n", data.OfType<Film>().SelectMany(film => film.Actors, (film, actor) => $"{actor.Name}: {film.Name}")));

        // Завдання 10
        Console.WriteLine($"Total page count: {data.OfType<Book>().Sum(book => book.Pages)} \n" +
                  $"Sum of all int values: {data.OfType<IEnumerable<int>>().SelectMany(seq => seq).Sum()}");

        // Завдання 11
        Console.WriteLine(string.Join("\n", data.OfType<Book>().GroupBy(book => book.Author).ToDictionary(group => group.Key, group => string.Join(", ", group.Select(book => book.Name)))));

        // Завдання 12
        Console.WriteLine(string.Join("\n", data.OfType<Film>().Where(film => film.Actors.Any(actor => actor.Name == "Matt Damon") && !data.OfType<string>().Any(name => film.Actors.Any(actor => actor.Name == name)))));

    }
}