using System;

public class Card {
    public int Number { get; set; }
    public CardColor Color { get; set; }

    public Card(int num, CardColor col)
    {
        Color = col;
        Number = num;
    }

    public Card() {}

    public override string ToString()
    {
        var s = "(" + Number + " " + Color + ")";
        return s;
    }
}