using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class Repo : IRepo
    {
        private Context context;


        public Repo(IDbContextFactory<Context> dbContextFactory)
        {
            context = dbContextFactory.CreateDbContext();
            context.Database.EnsureCreated();
        }

        public List<Deck> getDecks()
        {
            List<Deck> result = new List<Deck>();
            var pulledDecks = context.deckTables.Include(u => u.cards).ToList();

            foreach(var deck in pulledDecks){
                Card[] cards = new Card[deck.cards.Count];
                int idx = 0;
                foreach(var card in deck.cards)
                {
                    Card tmp = new Card(card.number, Enum.Parse<CardColor>(card.color));
                    cards[idx] = tmp;
                    idx++;
                }
                result.Add(new Deck(cards));
            }
            return result;
        }

        public void insertDeck(Deck deck)
        {
            List<CardTable> cards = new List<CardTable>();

            foreach(var card in deck.deck)
            {
                cards.Add(new CardTable()
                {
                    number = card.number,
                    color = card.color.ToString()
                });
            }

            var deckTable = new DeckTable()
            {
                cards = cards
            };

            context.AddRange(cards);
            context.Add(deckTable);
            context.SaveChanges();
        }
    }
}
