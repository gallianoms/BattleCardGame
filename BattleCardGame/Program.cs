
class Program
{
    static void Main(string[] args)
    {
        Deck deck = new();

        deck.Shuffle();

        deck.Print();

        System.Console.WriteLine("==============");
        System.Console.WriteLine(deck.DrawCardFromPosition(51));
        System.Console.WriteLine("==============");
        deck.Print();

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
            return suit switch
            {
                'h' => number + " of Hearts",
                's' => number + " of Spades",
                'd' => number + " of Diamonds",
                'c' => number + " of Clovers",
                _ => number + " of " + suit,
            };
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

        public void Shuffle()
        {
            Random random = new();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
        }

        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public Card DrawCardFromPosition(int position)
        {
            if (position < 0 || position >= cards.Count)
                throw new IndexOutOfRangeException();
            else
            {
                Card card = cards[position];
                cards.RemoveAt(position);
                return card;
            }
        }

        public Card DrawRandomCard()
        {
            Random random = new();
            return cards[random.Next(cards.Count)];
        }

        public void Print()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public List<Card> Cards { get => cards; set => cards = value; }
    }
}