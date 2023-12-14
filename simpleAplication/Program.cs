using model;
using model.card;
using model.generator;
using strategies;

namespace simpleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Card[] cards = new Card[2];
            cards[0] = new Card(13, CardColor.Black);
            cards[1] = new Card(2, CardColor.Red);

            ICardPickStrategy strategy = new SimpleCardPickStrategy();
            int index = strategy.Pick(cards);
            
            Console.WriteLine($"{cards[index].Value}, {cards[index].Color}");
            
            ICardDeckGenerator generator = new CardDeckGenerator();
            Card[] moreCards = generator.Generate();
            // Console.WriteLine($"{moreCards[0].Value}, {moreCards[index].Color}");

            foreach (var card in moreCards)
            {
                Console.WriteLine($"{card.Value}, {card.Color}");
            }
            Console.WriteLine(moreCards.Length);
        }
    }
}