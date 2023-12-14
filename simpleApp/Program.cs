using model.card;
using model.generator;
using model.shuffler;
using strategies;

namespace simpleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Cards:");
            Console.WriteLine("------------------");
            
            ICardDeckGenerator generator = new CardDeckGenerator();
            Card[] cards = generator.Generate();

            foreach (Card card in cards)
            {
                Console.WriteLine($"{card.Value}, {card.Color}");
            }
            
            Console.WriteLine("------------------");

            ICardDeckShuffler shuffler = new CardDeckShuffler();
            cards = shuffler.Shuffle(cards);
            
            ICardPickStrategy strategy = new SimpleCardPickStrategy();
            int pickedIndex = strategy.Pick(cards);
            
            Console.WriteLine($"{cards[pickedIndex].Value}, {cards[pickedIndex].Color}");
        }
    }
}