using model.card;
using model.generator;
using model.shuffler;
using application.player;

namespace application.experiments;

public class ColosseumSandbox : IColosseumSandbox
{
    private static readonly int CardsToEachPlayer = 18;
    private readonly IPlayer _firstPlayer;
    private readonly IPlayer _secondPlayer;
    private readonly Card[] _cards;
    private readonly ICardDeckShuffler _shuffler;
    
    public ColosseumSandbox(
        IEnumerable<IPlayer> providedPlayers, 
        ICardDeckGenerator generator, 
        ICardDeckShuffler shuffler)
    {
        List<IPlayer> selectedPlayers = providedPlayers.Take(2).ToList();
        if (selectedPlayers.Count >= 2)
        {
            _firstPlayer = selectedPlayers[0];
            _secondPlayer = selectedPlayers[1];
            Console.WriteLine($"First Player: {_firstPlayer}");
            Console.WriteLine($"Second Player: {_secondPlayer}");
        }
        else
        {
            throw new ArgumentException("expected 2 players");
        }
        _cards = generator.Generate();
        _shuffler = shuffler;
    }

    public bool Action()
    {
        Card[] shuffledCards = _shuffler.Shuffle(_cards);
        
        Card[] firstDeck = shuffledCards.Take(CardsToEachPlayer).ToArray();
        Card[] secondDeck = shuffledCards.Skip(CardsToEachPlayer).ToArray();

        int firstPick = _firstPlayer.SelectOpponentsCard(firstDeck);
        int secondPick = _secondPlayer.SelectOpponentsCard(secondDeck);

        return firstDeck[secondPick].Color == secondDeck[firstPick].Color;
    }
}