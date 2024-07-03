using System;

public class Card {
    public int number { get; set; }
    public CardColor color { get; set; }

    public Card(int num, CardColor col)
    {
        color = col;
        number = num;
    }

    public Card() {}

    public override string ToString()
    {
        var s = "(" + number + " " + color + ")";
        return s;
    }
}