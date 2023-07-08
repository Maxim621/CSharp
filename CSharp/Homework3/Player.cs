using System.Collections.Generic;

class Player
{
    public List<Card> Hand { get; set; }
    public int Score { get; set; }

    public Player()
    {
        Hand = new List<Card>();
        Score = 0;
    }

    public void ReceiveCard(Card card)
    {
        Hand.Add(card);
        Score += card.GetCardValue();
    }

    public void PrintHand()
    {
        foreach (Card card in Hand)
        {
            Console.WriteLine($"{card.Rank} of {card.Suit}");
        }
    }
}