using System;
using System.Collections;
using deck;

public class Shuffler {
    public virtual void shuffleDeck(Deck deck){
        Random rng = new Random();
        int n = deck.getSize();  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            deck.swap(k, n);
        }  
    }
}