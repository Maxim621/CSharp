using System;

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

class Card
{
    public Suit Suit { get; set; }
    public Rank Rank { get; set; }

    public int GetCardValue()
    {
        return (int)Rank;
    }
}