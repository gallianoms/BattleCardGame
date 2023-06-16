class Card
{
    private readonly char suit; // hearts (h), spades (s), diamonds (d), clovers (c)
    private readonly int number; // 0 (Ace), 1 (2), 2 (3), 3 (4), 4 (5), 5 (6), 6 (7), 7 (8), 8 (9), 9 (10), 10 (Jack), 11 (Queen), 12 (King)

    public char Suit { get => suit; }
    public int Number { get => number; }

    public Card(char suit, int number)
    {
        this.suit = suit;
        this.number = number;
    }

    public override string ToString()
    {
        return suit switch
        {
            'h' => number + " of Hearts",
            's' => number + " of Spades",
            'd' => number + " of Diamonds",
            'c' => number + " of Clovers",
            _ => number + " of " + suit,
        };
    }
}