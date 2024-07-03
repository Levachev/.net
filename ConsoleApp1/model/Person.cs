

public class Person {
    private Deck deck;
    private ICardPickStrategy strategy;
    public Person(ICardPickStrategy strategy){
        this.strategy = strategy;
    }

    public int move(){
        return strategy.Pick(deck.deck);
    }

    public void updateDeck(Deck deck){
        this.deck = deck;
    }

    public Card getCard(int position){
        return deck.getCard(position);
    }
}