using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db
{
    [Table("deck")]
    public class DeckTable
    {
        [Key]
        public int id { get; set; }

        public List<CardTable> cards { get; set; }
    }

    [Table("card")]
    public class CardTable
    {
        [Key]
        public int id { get; set; }
        public int number { get; set; }
        public String color { get; set; }

        [ForeignKey("deck")]
        public int deckId { get; set; }
        public DeckTable deck { get; set; }
    }
}
