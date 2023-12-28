using model.card;
using strategies;

namespace application.player;

public class Elon: IPlayer
{
    private readonly ICardPickStrategy _strategy;

    public Elon(ICardPickStrategy strategy)
    {
        _strategy = strategy;
        Name = "Elon";
    }

    public string Name { get; }

    public int SelectOpponentsCard(Card[] cards)
    {
        // Console.WriteLine("It is Elon");
        return _strategy.Pick(cards);
    }
    
    public override string ToString()
    {
        return "It is Elon";
    }
}
