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
}