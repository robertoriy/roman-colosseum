using model.card;

namespace strategies;

public interface ICardPickStrategy
{
    public int Pick(Card[] cards);
}