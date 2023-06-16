class Game
{
    private readonly List<Player> players;
    private readonly Deck deck;

    public List<Player> Players { get => players; }
    public Deck Deck { get => deck; }

    public Game()
    {
        players = new();
        deck = new();
    }

    public void Start()
    {
        int numberOfPlayers = GetNumberOfPlayers();

        CreatePlayers(numberOfPlayers);
        DealCards();

        while (!IsGameOver())
        {
            PlayRound();
        }

        List<Player> winners = DetermineWinner();
        if (winners.Count == 1)
        {
            Player winner = winners.First();
            Console.WriteLine($"The winner is {winner.Name}!");
        }
        else
        {
            Console.WriteLine("It's a tie! The winners are:");
            foreach (Player winner in winners)
            {
                Console.WriteLine(winner.Name);
            }
        }
    }

    private static int GetNumberOfPlayers()
    {
        Console.Write("Enter the number of players: ");
        int numberOfPlayers;
        while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || numberOfPlayers < 2 || numberOfPlayers > 5)
        {
            Console.Write("Please enter a number between 2 and 5: ");
        }
        return numberOfPlayers;
    }

    private void CreatePlayers(int numberOfPlayers)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.Write("Enter the name of player " + (i + 1) + ": ");
            string playerName = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Player " + (i + 1);
            }
            players.Add(new Player(playerName, new List<Card>()));
        }
    }

    private void DealCards()
    {
        deck.Shuffle();
        int currentPlayerIndex = 0;
        int cardsPerPlayer = deck.Cards.Count / players.Count;

        for (int i = 0; i < cardsPerPlayer; i++)
        {
            foreach (Player player in players)
            {
                Card card = deck.Cards[currentPlayerIndex];
                player.AddCardToHand(card);
                currentPlayerIndex++;
            }
        }
    }

    private bool IsGameOver()
    {
        return players.Any(player => player.HandIsEmpty());
    }

    private void PlayRound()
    {
        List<Card> roundCards = new();

        foreach (Player player in players)
        {
            Card? playedCard = player.PlayCard();
            if (playedCard != null)
            {
                roundCards.Add(playedCard);
                Console.WriteLine($"{player.Name} played {playedCard}");
            }
        }
        Console.WriteLine("\n");

        Card highestCard = roundCards.OrderByDescending(card => card.Number).First();

        foreach (Player player in players)
        {
            if (player.HasCard(highestCard))
            {
                player.AddCardsToBottomOfHand(roundCards);
                player.RemoveCardPlayed();
            }
            else
            {
                player.RemoveCardPlayed();
            }
        }

        foreach (Player player in players)
        {
            string playerHand = player.GetPlayerHand();
            Console.WriteLine(playerHand);
        }
    }

    private List<Player> DetermineWinner()
    {
        List<Player> winners = new();
        int maxCardCount = players.Max(player => player.Hand.Count);

        foreach (Player player in players)
        {
            if (player.Hand.Count == maxCardCount)
            {
                winners.Add(player);
            }
        }
        return winners;
    }
}
