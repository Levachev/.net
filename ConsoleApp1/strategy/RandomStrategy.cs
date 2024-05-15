
class RandomStrategy : Strategy {
    int Strategy.move(Deck deck){
        return new Random().Next(1, deck.getSize()+1);
    }
    
    void Strategy.updateStrategy(int opMove){
    }
}