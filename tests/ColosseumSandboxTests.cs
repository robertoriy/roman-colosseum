using application.experiments;
using application.player;
using model.generator;
using model.shuffler;
using strategies;
using model.card;
using Moq;

namespace tests;

public class ColosseumSandboxTests
{
    [Test]
    public void ShuffleOnlyOnce()
    {
        ICardPickStrategy strategy = new SimpleCardPickStrategy();
        Mock<ICardDeckShuffler> shufflerMock = new Mock<ICardDeckShuffler>();
        shufflerMock.Setup(shuffler => shuffler.Shuffle(It.IsAny<Card[]>())).Returns(new CardDeckGenerator().Generate());
        IColosseumSandbox sandbox = new ColosseumSandbox(
            new List<IPlayer>{new Mark(strategy), new Elon(strategy)},
            new CardDeckGenerator(), 
            shufflerMock.Object);
        
        sandbox.Action();
        
        shufflerMock.Verify(shuffler => shuffler.Shuffle(It.IsAny<Card[]>()), Times.Once);
    }
    
    [Test]
    public void ExperimentResultTrue()
    {
        Mock<ICardPickStrategy> strategyMarkMock = new Mock<ICardPickStrategy>();
        Mock<ICardPickStrategy> strategyElonMock = new Mock<ICardPickStrategy>();
        Mock<ICardDeckShuffler> shufflerMock = new Mock<ICardDeckShuffler>();
        prepareForTrueResult(strategyMarkMock, strategyElonMock, shufflerMock);
        IColosseumSandbox sandbox = new ColosseumSandbox(
            new List<IPlayer>{new Mark(strategyMarkMock.Object), new Elon(strategyElonMock.Object)},
            new CardDeckGenerator(), 
            shufflerMock.Object);
        
        bool actualResult = sandbox.Action();
        
        Assert.AreEqual(true, actualResult);
    }

    [Test]
    public void ExperimentResultFalse()
    {
        Mock<ICardPickStrategy> strategyMarkMock = new Mock<ICardPickStrategy>();
        Mock<ICardPickStrategy> strategyElonMock = new Mock<ICardPickStrategy>();
        Mock<ICardDeckShuffler> shufflerMock = new Mock<ICardDeckShuffler>();
        prepareForFalseResult(strategyMarkMock, strategyElonMock, shufflerMock);
        IColosseumSandbox sandbox = new ColosseumSandbox(
            new List<IPlayer>{new Mark(strategyMarkMock.Object), new Elon(strategyElonMock.Object)},
            new CardDeckGenerator(), 
            shufflerMock.Object);
        
        bool actualResult = sandbox.Action();
        
        Assert.AreEqual(false, actualResult);
    }
    
    private void prepareForTrueResult(
        Mock<ICardPickStrategy> strategyMarkMock,
        Mock<ICardPickStrategy> strategyElonMock,
        Mock<ICardDeckShuffler> shufflerMock
    )
    {
        strategyMarkMock.Setup(strategy => strategy.Pick(It.IsAny<Card[]>())).Returns(0);
        strategyElonMock.Setup(strategy => strategy.Pick(It.IsAny<Card[]>())).Returns(0);
        shufflerMock.Setup(shuffler => shuffler.Shuffle(It.IsAny<Card[]>())).Returns(new CardDeckGenerator().Generate());
    }

    private void prepareForFalseResult(
        Mock<ICardPickStrategy> strategyMarkMock,
        Mock<ICardPickStrategy> strategyElonMock,
        Mock<ICardDeckShuffler> shufflerMock
    )
    {
        strategyMarkMock.Setup(strategy => strategy.Pick(It.IsAny<Card[]>())).Returns(0);
        strategyElonMock.Setup(strategy => strategy.Pick(It.IsAny<Card[]>())).Returns(1);
        shufflerMock.Setup(shuffler => shuffler.Shuffle(It.IsAny<Card[]>())).Returns(new CardDeckGenerator().Generate());
    }
    
    
}