using System.Net.Http.Headers;
using deck;


public class Derby {
    private Shuffler shuffler;
    private Player person1;
    private Player person2;
    private Deck deck = new Deck();
    public Derby(Shuffler shuffler, Player person1, Player person2){
        this.shuffler = shuffler;
        this.person1 = person1;
        this.person2 = person2;
    }

    public bool singleExperiment(Deck deck)
    {
        shuffler.shuffleDeck(deck);

        (Deck person1Deck, Deck person2Deck) = separeteFullDaeck(deck);


        person1.updateDeck(person1Deck);
        person2.updateDeck(person2Deck);

        int person1Move = person1.move();
        int person2Move = person2.move();

        Card person1Card = person1.getCard(person2Move-1);
        Card person2Card = person2.getCard(person1Move-1);

        //Console.WriteLine("\n"+ilonCard.GetColor());
        //Console.WriteLine(markCard.GetColor()+"\n");

        return person1Card.color == person2Card.color;
    }

    private (Deck, Deck) separeteFullDaeck(Deck deck)
    {
        int deckSize = deck.getSize();
        Card[] ilonCards = new Card[deckSize / 2];
        Card[] markCards = new Card[deckSize / 2];
        for (int i = 0; i < deckSize / 2; i++)
        {
            ilonCards[i] = deck.getCard(i);
            markCards[i] = deck.getCard(deckSize / 2 + i);
        }
        Deck ilonDeck = new Deck(ilonCards);
        Deck markDeck = new Deck(markCards);

        return (ilonDeck, markDeck);
    }
}