namespace HoldEmTools;

public class HandAnalyzer
{
    private HashSet<Card> hand;
    private HashSet<Card> board;
    private CardParser _cardParser;

    public HandAnalyzer()
    {
        _cardParser = new CardParser();
        hand = new HashSet<Card>();
        board = new HashSet<Card>();
    }
    
    public void Run()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter hand in short-form notation: ");
                var handInput = Console.ReadLine();
                ParseHand(handInput);
                
                Console.WriteLine("Enter board: ");
                var boardInput = Console.ReadLine();
                ParseBoard(boardInput);
                
                Console.WriteLine(OddsBreakDown());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input, try again.");
            }
        }
    }

    private void ParseHand(string handInput)
    {
        var separatedCards = handInput.Split(" ");
        foreach (var card in separatedCards)
        {
            hand.Add(_cardParser.ParseSingleCard(card));
        }
    }

    private void ParseBoard(string boardInput)
    {
        var separatedCards = boardInput.Split(" ");
        foreach (var card in separatedCards)
        {
            board.Add(_cardParser.ParseSingleCard(card));
        }
    }

    private string OddsBreakDown()
    {
        return string.Empty;
    }

    // private double CalculateOnePairChances()
    // {
    //     if (IsSameRank())
    //     {
    //         return 1.0;
    //     }
    //
    //     double noPairChances = (44 / 50) * (43 / 49) * (42 / 48) * (41 / 47) * (40 / 46);
    //     return 1 - noPairChances;
    // }

    // private double CalculateTwoPairChances()
    // {
    //     
    // }

    private bool IsSameRank()
    {
        List<Card> cards = new List<Card>();
        foreach (var card in hand)
        {
            cards.Add(card);
        }

        return cards[0].Rank == cards[1].Rank;
    }
}