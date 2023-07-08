namespace CSharp.Homework3
{

    public class Game_card
    {
        public class Game
        {
            private Player player;
            private Player computer;
            private Deck deck;

            public int PlayerWins { get; private set; }
            public int ComputerWins { get; private set; }
            public int GamesPlayed { get; private set; }

            public Game()
            {
                player = new Player();
                computer = new Player();
                deck = new Deck();
                PlayerWins = 0;
                ComputerWins = 0;
                GamesPlayed = 0;
            }

            public void Play()
            {
                Console.WriteLine("Welcome to the game of 21!");

                while (true)
                {
                    StartNewRound();

                    Console.WriteLine("\nDo you want to play again? (Y/N)");
                    string playAgainResponse = Console.ReadLine().ToUpper();
                    if (playAgainResponse != "Y")
                    {
                        break;
                    }
                }

                Console.WriteLine("\nThank you for playing!");

                Console.WriteLine("\nOverall game statistics:");
                Console.WriteLine($"Games played: {GamesPlayed}");
                Console.WriteLine($"Player wins: {PlayerWins}");
                Console.WriteLine($"Computer wins: {ComputerWins}");
            }

            private void StartNewRound()
            {
                GamesPlayed++;

                Console.WriteLine("\nNew round started.");

                deck.Shuffle();

                player.Hand.Clear();
                computer.Hand.Clear();
                player.Score = 0;
                computer.Score = 0;

                player.ReceiveCard(deck.DrawCard());
                computer.ReceiveCard(deck.DrawCard());
                player.ReceiveCard(deck.DrawCard());
                computer.ReceiveCard(deck.DrawCard());

                Console.WriteLine("\nPlayer's hand:");
                player.PrintHand();

                Console.WriteLine("\nComputer's hand:");
                Console.WriteLine("Face down card");
                computer.PrintHand();

                PlayTurn(player);
                if (player.Score <= 21)
                {
                    PlayTurn(computer);
                }

                DetermineWinner();
            }

            private void PlayTurn(Player currentPlayer)
            {
                while (currentPlayer.Score < 21)
                {
                    Console.WriteLine("Do you want another card? (Y/N)");
                    string response = Console.ReadLine().ToUpper();

                    if (response == "Y")
                    {
                        currentPlayer.ReceiveCard(deck.DrawCard());
                        Console.WriteLine($"Your score: {currentPlayer.Score}");
                    }
                    else if (response == "N")
                    {
                        Console.WriteLine("You chose to stop.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }

            private void DetermineWinner()
            {
                int playerScore = player.Score;
                int computerScore = computer.Score;

                Console.WriteLine($"Player score: {playerScore}");
                Console.WriteLine($"Computer score: {computerScore}");

                if (playerScore > 21)
                {
                    Console.WriteLine("You have exceeded 21. You lose!");
                    ComputerWins++;
                }
                else if (playerScore == 21 || (player.Hand.Count == 2 && playerScore == 22))
                {
                    Console.WriteLine("Congratulations! You scored 21. You win!");
                    PlayerWins++;
                }
                else if (computerScore > 21)
                {
                    Console.WriteLine("Computer has exceeded 21. You win!");
                    PlayerWins++;
                }
                else if (computerScore == 21 || (computer.Hand.Count == 2 && computerScore == 22))
                {
                    Console.WriteLine("Computer scored 21. Computer wins!");
                    ComputerWins++;
                }
                else if (playerScore > computerScore)
                {
                    Console.WriteLine("You have a higher score. You win!");
                    PlayerWins++;
                }
                else if (playerScore < computerScore)
                {
                    Console.WriteLine("Computer has a higher score. Computer wins!");
                    ComputerWins++;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }
            }
        }
    }
}