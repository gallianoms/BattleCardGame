using System.Text;

class Player
{
    private readonly string name;
    private List<Card> hand;

    public string Name { get => name; }
    public List<Card> Hand { get => hand; set => hand = value; }

    public Player(string name, List<Card> hand)
    {
        this.name = name;
        this.hand = hand;
    }

    public void AddCardToHand(Card card)
    {
        hand.Add(card);
    }

    public Card? PlayCard()
    {
        if (hand.Count == 0)
            return null;

        Card card = hand[0];
        return card;
    }

    public bool HandIsEmpty()
    {
        if (hand.Count == 0)
            return true;
        else
            return false;
    }

    public bool HasCard(Card card)
    {
        return hand.Contains(card);
    }

    public int GetHighestCardNumber()
    {
        if (Hand.Count == 0)
            return 0;

        return Hand.Max(card => card.Number);
    }

    public void AddCardsToBottomOfHand(List<Card> cards)
    {
        hand.AddRange(cards);
    }

    public void RemoveCardPlayed()
    {
        hand.RemoveAt(0);
    }

    public string GetPlayerHand()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.AppendLine($"Hand of {name}:");
        foreach (Card card in hand)
        {
            stringBuilder.AppendLine(card.ToString());
        }

        return stringBuilder.ToString();
    }
}
