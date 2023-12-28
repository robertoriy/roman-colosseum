using model.card;
using model.generator;
using model.shuffler;
using application.experiments;
using application.player;
using strategies;

namespace application
{
    public class SimpleProgram
    {
        // public static void Main(string[] args)
        // {
        //     ICardPickStrategy strategy = new SimpleCardPickStrategy();
        //     IPlayer mark = new Mark(strategy);
        //     IPlayer elon = new Elon(strategy);
        //     ICardDeckGenerator generator = new CardDeckGenerator();
        //     ICardDeckShuffler shuffler = new CardDeckShuffler();
        //     
        //     ColosseumSandbox sandbox = new ColosseumSandbox(
        //         new List<IPlayer>{mark, elon}, 
        //         generator, 
        //         shuffler
        //         );
        //     
        //     ColosseumExperimentWorker experimentWorker = new ColosseumExperimentWorker(
        //         sandbox, 
        //         null, 
        //         null
        //         );
        //     
        //     experimentWorker.CountStats();
        // }
    }
}