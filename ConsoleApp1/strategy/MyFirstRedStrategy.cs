
class MyFirstRedStrategy : Strategy {

    int Strategy.move(Deck deck){
        return findFirstRed(deck);
    }

    public int findFirstRed(Deck deck){
        int ret = 0;
        for(int i=0;i<deck.getSize();i++){
            if(deck.getCard(i).GetColor() == Color.red){
                ret = i+1;
                break;
            }
        }
        return ret;
    }

    void Strategy.updateStrategy(int opMove){
    }
}