using model.card;

namespace model.shuffler;

public class CardDeckShuffler : ICardDeckShuffler
{
    private static readonly Random Random = new Random();
    
    public Card[] Shuffle(Card[] cards)
    {
        for (int i = cards.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Next(i + 1);
            (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
        }
        return cards;
    }
}