using System;
using System.Collections;

static class Generator {
    public static void shuffleDeck(Deck deck){
        Random rng = new Random();
        int n = deck.getSize();  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            deck.swap(k, n);
        }  
    }
    
    public static Deck generateDeck(){
        List<Card> deck = new List<Card>();
        foreach(Suit suit in Enum.GetValues(typeof(Suit))){
            foreach(CardValue value in Enum.GetValues(typeof(CardValue))){
                Card tmp = new Card(suit, value);
                deck.Add(tmp);
            }
        }

        return new Deck(deck);
    }
}