using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db
{
    [Table("deck")]
    public class DeckTable
    {
        [Key]
        public int id;
        public List<CardTable> cards;
    }

    [Table("card")]
    public class CardTable
    {
        [Key]
        public int id;
        public int number;
        public String color;

        [ForeignKey("deck")]
        public int deckId;
        public DeckTable deck;
    }
}
