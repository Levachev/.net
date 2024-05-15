
class RepeatStrategy : Strategy {
    private int lastMove = 1;

    int Strategy.move(Deck deck){
        return lastMove;
    }

    void Strategy.updateStrategy(int opMove){
        lastMove = opMove;
    }
}