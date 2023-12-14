using model.card;

namespace model.generator;

public class CardDeckGenerator: ICardDeckGenerator
{
    private const int DefaultDeckSize = 32;
    
    public Card[] Generate()
    {
        Card[] cards = new Card[DefaultDeckSize];
        int redCounter = 0;
        int blackCounter = 0;
        
        for (int i = 0; i < DefaultDeckSize; i++)
        {
            if (i % 2 == 0)
            {
                cards[i] = new Card(redCounter++, CardColor.Black);
            }
            else
            {
                cards[i] = new Card(blackCounter++, CardColor.Red);
            }
        }

        return cards;
    }
}