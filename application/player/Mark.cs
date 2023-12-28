using model.card;
using strategies;

namespace application.player;

public class Mark : IPlayer
{
    private readonly ICardPickStrategy _strategy;

    public Mark(ICardPickStrategy strategy)
    {
        _strategy = strategy;
        Name = "Mark";
    }

    public string Name { get; }

    public int SelectOpponentsCard(Card[] cards)
    {
        // Console.WriteLine("it is Mark");
        return _strategy.Pick(cards);
    }

    public override string ToString()
    {
        return "It is Mark";
    }
}
