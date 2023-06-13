class Program
{
    static void Main(string[] args)
    {
        Deck deck = new();

        foreach (Card card in deck.Cards)
        {
            Console.WriteLine(card);
        }

        Console.ReadKey();
    }

    class Card
    {
        private char suit; // hearts (h), spades (s), diamonds (d), clovers (c)
        private int number; // 0 (Ace), 1 (2), 2 (3), 3 (4), 4 (5), 5 (6), 6 (7), 7 (8), 8 (9), 9 (10), 10 (Jack), 11 (Queen), 12 (King)

        public Card(char suit, int number)
        {
            this.suit = suit;
            this.number = number;
        }

        public override string ToString()
        {
            return number + " of " + suit;
        }

        public char Suit { get => suit; set => suit = value; }
        public int Number { get => number; set => number = value; }
    }

    class Deck
    {
        List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            char[] suits = { 'h', 's', 'd', 'c' };
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            foreach (char suit in suits)
            {
                foreach (int number in numbers)
                {
                    Card card = new(suit, number);
                    cards.Add(card);
                }
            }
        }

        public List<Card> Cards { get => cards; set => cards = value; }
    }
}