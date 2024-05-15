using System;

class Card {
    private Suit suit;
    private CardValue value;

    public Card(Suit suit, CardValue value){
        this.suit = suit;
        this.value = value;
    }

    public Color GetColor(){
        return SuitUtil.getColor(suit);
    }

    public Suit GetSuit(){
        return suit;
    }

    public CardValue GetCardValue(){
        return value;
    }
}