using model.card;

namespace application.player;

public interface IPlayer
{
    public int SelectOpponentsCard(Card[] cards);
}