using System;

namespace cardPick
{
    public class CardPick
    {
        public int number { get; set; }
        public string name { get; set; }

        public CardPick(int number, string name)
        {
            this.name = name;
            this.number = number;
        }

        public CardPick() { }
    }
}
