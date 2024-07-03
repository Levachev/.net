
public class MyFirstRedStrategy : ICardPickStrategy{

    int ICardPickStrategy.Pick(Card[] cards){
        return findFirstRed(cards);
    }

    private int findFirstRed(Card[] cards){
        int ret = 0;
        for(int i=0;i<cards.Length;i++){
            if(cards[i].Color == CardColor.Red){
                ret = i+1;
                break;
            }
        }
        return ret;
    }
}