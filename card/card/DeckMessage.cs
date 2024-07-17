using deck;

namespace deckMessage
{
    public class DeckMessage
    {
        public Deck deck { get; set; }

        public DeckMessage()
        {
        }

        public DeckMessage(Deck deck)
        {
            this.deck = deck;
        }
    }
}
