using model.generator;
using model.card;

namespace tests;

public class CardDeckGeneratorTests
{
    [Test]
    public void CardDeckHas18BlackAndRedCards()
    {
        ICardDeckGenerator generator = new CardDeckGenerator();

        Card[] cards = generator.Generate();
        int redCount = cards.Count(card => card.Color == CardColor.Red);
        int blackCount = cards.Count(card => card.Color == CardColor.Black);

        Assert.AreEqual(18, redCount);
        Assert.AreEqual(18, blackCount);
    }
}