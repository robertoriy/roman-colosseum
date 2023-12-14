namespace model.card;

public class Card
{
    public Card(int value, CardColor color)
    {
        if (value < 0 || value > 15)
        {
            throw new ArgumentException("Invalid card value");
        }
        Value = value;
        Color = color;
    }

    public int Value { get; }
    
    public CardColor Color { get; }
    
    public override bool Equals(object? obj)
    {
        if ((obj == null) || !ReferenceEquals(this.GetType(), obj.GetType()))
        {
            return false;
        }
        if (obj == this)
        {
            return true;
        }
        Card other = (Card) obj;
        return Value == other.Value && Color == other.Color;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)Color);
    }
}