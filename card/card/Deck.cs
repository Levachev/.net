
namespace deck
{
    public class Deck
    {
        public Card[] deck;

        public Deck()
        {
            deck = new Card[36];
            GenerateDeck();
        }

        public Deck(Card[] inputDeck)
        {
            deck = inputDeck;
        }

        public Card getCard(int position)
        {
            return deck[position];
        }

        public int getSize()
        {
            return deck.Length;
        }

        public void swap(int k, int n)
        {
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }

        private void GenerateDeck()
        {
            for (var i = 0; i < 36; i++)
            {
                if (i < 18)
                {
                    deck[i] = new Card(i + 1, CardColor.Red);
                }
                else
                {
                    deck[i] = new Card(i + 1, CardColor.Black);
                }
            }
        }

    }
}