using model.card;

namespace model.generator;

public interface ICardDeckGenerator
{
    public Card[] Generate();
}