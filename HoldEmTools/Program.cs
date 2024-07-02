namespace HoldEmTools;

class Program
{
    private static BoardAnalyzer _boardAnalyzer;
    private static ImpliedOddsCalculator _impliedOddsCalculator;
    
    static void Main(string[] args)
    {
        string[] options = { "--board-analyzer", "--implied-odds", "--hand-analyzer" };
        
        if (args.Length != 1 || !options.Contains(args[0]))
        {
            PrintUsage();
            return;
        }
        
        if (args[0] == "--board-analyzer")
        {
            _boardAnalyzer = new BoardAnalyzer();
            _boardAnalyzer.Run();
        }
        else if (args[0] == "--implied-odds")
        {
            _impliedOddsCalculator = new ImpliedOddsCalculator();
            _impliedOddsCalculator.Run();
        }
        else
        {
            Console.WriteLine("Coming soon....");
        }
    }

    static void PrintUsage()
    {
        Console.WriteLine("======HoldEmTools======");
        Console.WriteLine();
        Console.WriteLine("usage: het [options]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --board-analyzer   Analyze a board texture");
        Console.WriteLine("  --implied-odds     Calculate implied odds");
        Console.WriteLine("  --hand-analyzer    Analyze odds of making various hands");
    }

}




