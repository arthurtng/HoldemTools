namespace HoldEmTools;

public class BoardAnalyzer
{
    // Analyse a board for wetness-dryness, static-dynamic
    private HashSet<Card> board;
    private CardParser _cardParser;

    public BoardAnalyzer()
    {
        board = new HashSet<Card>();
        _cardParser = new CardParser();
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter a flop in short-form notation: ");
            var input = Console.ReadLine();

            try
            {
                var separatedCards = input.Split(" ");

                if (separatedCards.Length != 3)
                {
                    throw new Exception("Flop must contain 3 cards only.");
                }

                foreach (var card in separatedCards)
                {
                    if (card.Length != 2)
                    {
                        throw new Exception("Short-form notation should only have 2 characters");
                    }

                    var cardObject = _cardParser.ParseSingleCard(card);
                    if (board.Contains(cardObject))
                    {
                        throw new Exception("There's only one of each card in a deck!");
                    }
                    board.Add(cardObject);
                }

                var wetnessScore = WetnessScore(board);

                if (wetnessScore == 1)
                {
                    Console.WriteLine("This flop is semi-wet with a wetness score of 1");
                }
                else if (wetnessScore == 2)
                {
                    Console.WriteLine("This flop is wet with a wetness score of 2");
                }
                else if (wetnessScore >= 3)
                {
                    Console.WriteLine("This flop is soaking wet with a wetness score of over 2");
                }
                else
                {
                    Console.WriteLine("This flop is dry.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input, try again: {ex.Message}");
            }
        }
    }

    private int WetnessScore(HashSet<Card> board)
    {
        var score = 0;
        
        // How monotone is the board
        var sameSuitCount = SameSuitCount(board);
        if (sameSuitCount >= 2)
        {
            score += sameSuitCount - 1;
        }
        
        // How connected is the board
        score += ConnectedCount(board) - 1;
        
        return score;
    }

    private int SameSuitCount(HashSet<Card> board)
    {
        // TODO: Suitedness score needs to take into account situation where 2 suits with 2 or more cards are present
        // for turn and river boards
        var cards = new Dictionary<Suit, int>();
        foreach (var card in board)
        {
            if (cards.ContainsKey(card.Suit))
            {
                cards[card.Suit] += 1;
            }
            else
            {
                cards[card.Suit] = 1;
            }
        }

        foreach (var card in cards)
        {
            if (card.Value >= 2)
            {
                return card.Value;
            }
        }

        return 0;
    }

    private int ConnectedCount(HashSet<Card> board)
    {
        // TODO: connectedness score should also take into account 1-gappers, but giving them a lesser score
        // Find how many cards are connected together
        var num = 0;
        var cards = new List<int>();
        foreach (var card in board)
        {
            cards.Add(card.Rank);
        }
        cards.Sort();

        var idx = 1;
        while (idx < cards.Count)
        {
            if (cards[idx] - cards[idx-1] == 1)
            {
                num += 1;
            }
            idx += 1;
        }

        return num + 1;
    }
}