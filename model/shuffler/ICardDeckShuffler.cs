using model.card;

namespace model.shuffler;

public interface ICardDeckShuffler
{
    Card[] Shuffle(Card[] cards);
}