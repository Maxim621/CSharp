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
        Console.WriteLine(string.Join(", ", data.Where(item => !(item is ArtObject))));

        // Завдання 2
        Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(film => film.Actors).Select(actor => actor.Name)));

        // Завдання 3
        Console.WriteLine(data.OfType<Film>().SelectMany(film => film.Actors).Count(actor => actor.Birthdate.Month == 8));

        // Завдання 4
        Console.WriteLine(string.Join(", ", data.OfType<Film>().SelectMany(film => film.Actors).OrderByDescending(actor => actor.Birthdate).Take(2).Select(actor => actor.Name)));

        // Завдання 5
        Console.WriteLine(string.Join(", ", data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"{group.Key}: {group.Count()}")));

        // Завдання 6
        Console.WriteLine($"Books per author: {data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"{group.Key}: {group.Count()}").FirstOrDefault()}");
        Console.WriteLine($"Films per director: {data.OfType<Film>().GroupBy(film => film.Author).Select(group => $"{group.Key}: {group.Count()}").FirstOrDefault()}");

        // Завдання 7
        Console.WriteLine(data.OfType<Film>().SelectMany(film => film.Actors).SelectMany(actor => actor.Name.ToLower()).Distinct().Count());

        // Завдання 8
        Console.WriteLine(string.Join(", ", data.OfType<Book>().OrderBy(book => book.Author).ThenBy(book => book.Pages).Select(book => $"{book.Name} ({book.Author}): {book.Pages} pages")));

        // Завдання 9
        var actorName = "Matt Damon";
        Console.WriteLine($"{actorName}'s films:");
        Console.WriteLine(string.Join(", ", data.OfType<Film>().Where(film => film.Actors.Any(actor => actor.Name == actorName)).Select(film => film.Name)));

        // Завдання 10
        var totalPageCount = data.OfType<Book>().Sum(book => book.Pages);
        var intValues = data.OfType<IEnumerable<int>>().SelectMany(seq => seq).Sum();
        Console.WriteLine($"Total page count: {totalPageCount}");
        Console.WriteLine($"Sum of all int values: {intValues}");

        // Завдання 11
        var authorBooks = data.OfType<Book>().GroupBy(book => book.Author).ToDictionary(group => group.Key, group => group.ToList());
        foreach (var author in authorBooks)
        {
            Console.WriteLine($"Author: {author.Key}");
            Console.WriteLine(string.Join(", ", author.Value.Select(book => book.Name)));
        }

        // Завдання 12
        var excludedActorNames = data.OfType<string>().ToList();
        var mattDamonFilms = data.OfType<Film>().Where(film => film.Actors.All(actor => !excludedActorNames.Contains(actor.Name)) && film.Actors.Any(actor => actor.Name == "Matt Damon"));
        foreach (var film in mattDamonFilms)
        {
            Console.WriteLine(film.Name);
        }

    }
}