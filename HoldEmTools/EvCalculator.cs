namespace HoldEmTools;

public class EvCalculator
{
    public void Run()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Enter pot size: ");
                var potSize = Int32.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter amount to call: ");
                var herosBet = Int32.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter win percentage: ");
                var winPercentage = Int32.Parse(Console.ReadLine());

                var ev = CalculateEv(potSize, herosBet, (double)winPercentage / 100);
                Console.WriteLine($"Your expected value is ${ev}.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong input, try again.");
            }
        }
    }
    
    
    private double CalculateEv(int pot, int heroBet, double winPercentage, bool isCall = true)
    {
        double win;
        if (isCall)
        {
            win = winPercentage * (pot);
        }
        else
        {
            win = winPercentage * (pot + heroBet);
        }
        var loss = (1 - winPercentage) * heroBet;
        return win - loss;
    }
}