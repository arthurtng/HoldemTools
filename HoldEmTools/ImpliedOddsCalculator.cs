namespace HoldEmTools;

public class ImpliedOddsCalculator
{
    
    public void Run()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter amount to call: ");
                var callAmount = Double.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter Opponents' Bets Total: ");
                var opponentsBet = Double.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter Pot Size Excluding Bets:");
                var potSize = Double.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter Hand Equity Percentage:");
                var handEquity = Double.Parse(Console.ReadLine()) / 100;

                var impliedOdds = CalculateImpliedOdds(callAmount, opponentsBet, potSize, handEquity);
                Console.WriteLine($"You need to win ${impliedOdds} to call.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input, try again.");
            }
        }
    }

    private double CalculateImpliedOdds(double callAmount, double opponentsBet, double potSize, double handEquity)
    {
        return (callAmount - handEquity * (callAmount + opponentsBet + potSize)) / handEquity;
    }
}