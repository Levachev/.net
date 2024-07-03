using System;

namespace AppTests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void TestDeck()
        {
            Deck deck = new Deck();
            int redCadrNumber = 0;
            int blackCadrNumber = 0;

            foreach(Card card in deck.deck)
            {
                if (card.color == CardColor.Red)
                {
                    redCadrNumber++;
                }
                else
                {
                    blackCadrNumber++;
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(redCadrNumber, Is.EqualTo(18));
                Assert.That(blackCadrNumber, Is.EqualTo(18));
            });
        }
    }
}
