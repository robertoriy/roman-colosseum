using model.generator;
using strategies;
using model.generator;
using model.card;


namespace tests;

public class SimpleCardPickStrategyTests
{
    private static readonly int SHUFFLE_INDEX = 11;
        
    [Test]
    public void PickingExpectedCardWithSimplePickStrategy()
    {
        ICardPickStrategy strategy = new SimpleCardPickStrategy();
        Card[] cards = new CardDeckGenerator().Generate();
        int expectedValue = cards[SHUFFLE_INDEX].Value;
        CardColor expectedColor = cards[SHUFFLE_INDEX].Color;
        
        cards = ShuffleInCertainWay(cards);
        int pickIndex = strategy.Pick(cards);
        int actualValue = cards[pickIndex].Value;
        CardColor actualColor = cards[pickIndex].Color;

        Assert.AreEqual(expectedValue, actualValue);
        Assert.AreEqual(expectedColor, actualColor);
    }

    public Card[] ShuffleInCertainWay(Card[] cards)
    {
        (cards[0], cards[SHUFFLE_INDEX]) = (cards[SHUFFLE_INDEX], cards[0]);
        return cards;
    }
}