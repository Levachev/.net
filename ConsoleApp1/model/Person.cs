

class Person {
    private Deck deck;
    private Strategy strategy;
    public Person(Strategy strategy){
        this.strategy = strategy;
    }

    public int move(){
        return strategy.move(deck);
    }

    public void updateDeck(Deck deck){
        this.deck = deck;
    }

    public void updateStrategy(int opMove){
        strategy.updateStrategy(opMove);
    }

    public Card getCard(int position){
        return deck.getCard(position);
    }
}