using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework3
{

    public class Game_card
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
            Ace = 11,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 2,
            Queen = 3,
            King = 4
        }

        public static void Start()
        {
            int playerScore = 0;
            int computerScore = 0;
            int gamesPlayed = 0;
            int playerWins = 0;
            int computerWins = 0;
            bool continuePlaying = true;
            Random random = new Random();

            Console.WriteLine("Welcome to the game of 21!");

            while (continuePlaying)
            {
                gamesPlayed++;

                Console.WriteLine("\nNew Game:");

                List<string> deck = CreateDeck();

                ShuffleDeck(deck, random);

                List<string> playerHand = new List<string>();
                List<string> computerHand = new List<string>();

                DealInitialCards(deck, playerHand, computerHand);

                bool playerTurn = DetermineFirstPlayer();

                Console.WriteLine("\nYour turn!");

                playerScore = CalculateScore(playerHand);
                Console.WriteLine($"Your score: {playerScore}");

                while (playerTurn)
                {
                    Console.WriteLine("Do you want another card? (Y/N)");
                    string response = Console.ReadLine().ToUpper();

                    if (response == "Y")
                    {
                        DealCard(deck, playerHand);
                        playerScore = CalculateScore(playerHand);
                        Console.WriteLine($"Your score: {playerScore}");

                        if (playerScore > 21)
                        {
                            Console.WriteLine("You have exceeded 21. You lose!");
                            computerWins++;
                            playerTurn = false;
                        }
                        else if (playerScore == 21)
                        {
                            Console.WriteLine("Congratulations! You scored 21. You win!");
                            playerWins++;
                            playerTurn = false;
                        }
                    }
                    else if (response == "N")
                    {
                        Console.WriteLine("You chose to stop. It's computer's turn now.");
                        playerTurn = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }

                if (playerScore <= 21)
                {
                    Console.WriteLine("\nComputer's turn!");

                    computerScore = CalculateScore(computerHand);

                    while (computerScore < playerScore && computerScore < 21)
                    {
                        DealCard(deck, computerHand);
                        computerScore = CalculateScore(computerHand);
                    }

                    Console.WriteLine($"Computer score: {computerScore}");

                    if (computerScore > 21)
                    {
                        Console.WriteLine("Computer has exceeded 21. You win!");
                        playerWins++;
                    }
                    else if (computerScore == 21)
                    {
                        Console.WriteLine("Computer scored 21. Computer wins!");
                        computerWins++;
                    }
                    else
                    {
                        if (computerScore > playerScore)
                        {
                            Console.WriteLine("Computer has a higher score. Computer wins!");
                            computerWins++;
                        }
                        else if (playerScore > computerScore)
                        {
                            Console.WriteLine("You have a higher score. You win!");
                            playerWins++;
                        }
                        else
                        {
                            Console.WriteLine("It's a tie!");
                        }
                    }
                }

                Console.WriteLine("\nGame over!");
                Console.WriteLine($"Player wins: {playerWins}");
                Console.WriteLine($"Computer wins: {computerWins}");

                Console.WriteLine("\nDo you want to play again? (Y/N)");
                string playAgainResponse = Console.ReadLine().ToUpper();
                continuePlaying = (playAgainResponse == "Y");
            }

            Console.WriteLine("\nThank you for playing!");

            Console.WriteLine("\nOverall game statistics:");
            Console.WriteLine($"Games played: {gamesPlayed}");
            Console.WriteLine($"Player wins: {playerWins}");
            Console.WriteLine($"Computer wins: {computerWins}");
        }

        static List<string> CreateDeck()
        {
            List<string> deck = new List<string>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            return deck;
        }

        static void ShuffleDeck(List<string> deck, Random random)
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string temp = deck[k];
                deck[k] = deck[n];
                deck[n] = temp;
            }
        }

        static void DealInitialCards(List<string> deck, List<string> playerHand, List<string> computerHand)
        {
            DealCard(deck, playerHand);
            DealCard(deck, computerHand);
            DealCard(deck, playerHand);
            DealCard(deck, computerHand);

            Console.WriteLine("\nPlayer's hand:");
            foreach (string card in playerHand)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("\nComputer's hand:");
            Console.WriteLine(computerHand[0]);
            Console.WriteLine("Face down card");
        }

        static void DealCard(List<string> deck, List<string> hand)
        {
            string card = deck[0];
            deck.RemoveAt(0);
            hand.Add(card);
        }

        static bool DetermineFirstPlayer()
        {
            Console.WriteLine("Who receives the first cards? (P/C)");
            string response = Console.ReadLine().ToUpper();
            return (response == "P");
        }

        static int CalculateScore(List<string> hand)
        {
            int score = 0;

            foreach (string card in hand)
            {
                Rank rank = (Rank)Enum.Parse(typeof(Rank), card.Split()[0]);
                score += (int)rank;
            }

            return score;
        }
    }
}