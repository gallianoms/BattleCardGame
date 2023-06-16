using System.Text;

class Deck
{
    List<Card> cards;

    public List<Card> Cards { get => cards; set => cards = value; }

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

    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (Card card in Cards)
        {
            sb.AppendLine(card.ToString());
        }
        return sb.ToString();
    }
}
