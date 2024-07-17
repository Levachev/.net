using deck;

namespace AppTests
{
    [TestFixture]
    public class StrategyTests
    {

        [Test]
        public void TestFirstRedStrategy()
        {
            var deck = new Deck();
            deck.deck[0] = new Card(1, CardColor.Red);

            ICardPickStrategy strategy = new MyFirstRedStrategy();
            int result = strategy.Pick(deck.deck);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestRandomStrategy()
        {
            ICardPickStrategy strategy = new RandomStrategy();
            int result = strategy.Pick(new Deck().deck);

            Assert.GreaterOrEqual(result, 1);
            Assert.LessOrEqual(result, 36);
        }
    }
}
