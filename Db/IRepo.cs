using Microsoft.EntityFrameworkCore;

namespace Db
{
    public interface IRepo
    {
        List<Deck> getDecks();
        public void insertDeck(Deck deck);
    }
}
