using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework3
{
    enum Suit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    enum Rank
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    public class Tasks
    {
        public static void Start()
        {
            string[] deck = new string[52];
            int index = 0;

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck[index] = $"{rank} of {suit}";
                    index++;
                }
            }

            Console.WriteLine("Ordered deck of cards:");
            PrintDeck(deck);

            ShuffleDeck(deck);

            Console.WriteLine("\nShuffled deck of cards:");
            PrintDeck(deck);

            int[] acePositions = FindAcePositions(deck);

            Console.WriteLine("\nPositions of all Aces in the deck:");
            PrintAcePositions(acePositions);

            MoveSpadesToBeginning(deck);

            Console.WriteLine("\nDeck with moved Spades cards:");
            PrintDeck(deck);

            SortDeck(deck);

            Console.WriteLine("\nSorted deck of cards:");
            PrintDeck(deck);
        }

        static void ShuffleDeck(string[] deck)
        {
            Random random = new Random();
            int n = deck.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string temp = deck[k];
                deck[k] = deck[n];
                deck[n] = temp;
            }
        }

        static int[] FindAcePositions(string[] deck)
        {
            int[] acePositions = new int[4];
            int index = 0;

            for (int i = 0; i < deck.Length; i++)
            {
                if (deck[i].StartsWith("Ace"))
                {
                    acePositions[index] = i;
                    index++;
                }
            }

            return acePositions;
        }

        static void MoveSpadesToBeginning(string[] deck)
        {
            int spadesCount = 0;
            int index = 0;

            while (index < deck.Length && spadesCount < 13)
            {
                if (deck[index].EndsWith("Spades"))
                {
                    string temp = deck[index];
                    for (int i = index; i > spadesCount; i--)
                    {
                        deck[i] = deck[i - 1];
                    }
                    deck[spadesCount] = temp;
                    spadesCount++;
                }
                index++;
            }
        }

        static void SortDeck(string[] deck)
        {
            Array.Sort(deck);
        }

        static void PrintDeck(string[] deck)
        {
            foreach (string card in deck)
            {
                Console.WriteLine(card);
            }
        }

        static void PrintAcePositions(int[] acePositions)
        {
            for (int i = 0; i < acePositions.Length; i++)
            {
                Console.WriteLine($"Ace {i + 1} is at position {acePositions[i] + 1}");
            }
        }
    }
}
