namespace HoldEmTools;

public class Deck
{
    private List<Card> Cards;

    public Deck()
    {
        Cards = new List<Card>();
        int i = 1;
        while (i <= (int)Ranks.King)
        {
            var cards = new[]
            {
                new Card(Suit.Hearts, i),
                new Card(Suit.Diamonds, i),
                new Card(Suit.Spades, i),
                new Card(Suit.Clubs, i)
            };
            Cards.AddRange(cards);
            i++;
        }
    }
}

public class Card
{
    public Suit Suit;
    public int Rank;

    public Card(Suit suit, int rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public string ShortForm()
    {
        string result = "";
        if (Rank == (int)Ranks.Ace)
        {
            result += "A";
        }
        else if (Rank < (int)Ranks.Ten)
        {
            result += Rank.ToString();
        }
        else
        {
            result += ((Ranks)Rank).ToString()[0];
        }

        result += Suit.ToString().ToLower()[0];
        return result;
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Card other = (Card)obj;
        return Rank == other.Rank && Suit == other.Suit;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Rank, Suit);
    }
}

public enum Suit
{
    Hearts,
    Diamonds,
    Spades,
    Clubs
}

public enum Ranks
{
    Ace = 1,
    Deuce = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}

public class CardParser
{
    public Card ParseSingleCard(string shortForm)
    {
        Ranks rank;
        switch (shortForm[0].ToString().ToUpper())
        {
            case "A":
                rank = Ranks.Ace;
                break;
            case "J":
                rank = Ranks.Jack;
                break;
            case "Q":
                rank = Ranks.Queen;
                break;
            case "K":
                rank = Ranks.King;
                break;
            case "T":
                rank = Ranks.Ten;
                break;
            default:
                Int32.TryParse(shortForm[0].ToString(), out var num);
                if (num == 0)
                {
                    throw new Exception("Failed to parse card rank");
                }
                rank = (Ranks)num;
                break;
        }

        Suit suit = 0;
        switch (shortForm[1])
        {
            case 'h':
                suit = Suit.Hearts;
                break;
            case 'c':
                suit = Suit.Clubs;
                break;
            case 's':
                suit = Suit.Spades;
                break;
            case 'd':
                suit = Suit.Diamonds;
                break;
            default:
                throw new Exception("This is not a valid suit");
        }

        return new Card(suit, (int)rank);
    }
    
}
