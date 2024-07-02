
class RandomStrategy : ICardPickStrategy{
    int ICardPickStrategy.Pick(Card[] cards){
        return new Random().Next(1, cards.Length+1);
    }
}