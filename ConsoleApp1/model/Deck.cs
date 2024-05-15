

class Deck {
    private List<Card> deck;

    public Deck(List<Card> inputDeck){
        deck = inputDeck;
    }

    public Card getCard(int position){
        return deck[position];
    }

    public int getSize(){
        return deck.Count;
    }

    public void swap(int k, int n){
        Card value = deck[k];  
        deck[k] = deck[n];  
        deck[n] = value;  
    }

}