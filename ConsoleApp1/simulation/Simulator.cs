

using System.Runtime.InteropServices;

class Simulator {
    private int iterationCapasity;

    public Simulator(int iterationCapasity){
        this.iterationCapasity = iterationCapasity;
    }

    private (Deck, Deck) separeteFullDaeck(Deck deck){
        int deckSize = deck.getSize();
        Card[] ilonCards = new Card[deckSize/2];
        Card[] markCards = new Card[deckSize/2];
        for(int i=0;i<deckSize/2;i++){
            ilonCards[i] = deck.getCard(i);
            markCards[i] = deck.getCard(deckSize/2+i);
        }
        Deck ilonDeck = new Deck(ilonCards);
        Deck markDeck = new Deck(markCards);

        return (ilonDeck, markDeck);
    }

    private void printDeck(List<Card> deck){
        foreach(Card card in deck){
            Console.WriteLine(card.Number+" "+card.Color);
        }
    }

    public int simulate(string ilonStrategyName, string markStrategyName){
        Deck deck = new Deck();

        ICardPickStrategy ilonStrategy = StrategyFactory.createForName(ilonStrategyName);
        ICardPickStrategy markStrategy = StrategyFactory.createForName(markStrategyName);

        Person ilon = new Person(ilonStrategy);
        Person mark = new Person(markStrategy);

        int succesCounter = 0;

        Derby derby = new Derby(ilon, mark);

        for(int i=0;i<iterationCapasity;i++){
            Generator.shuffleDeck(deck);

            (Deck ilonDeck, Deck markDeck) = separeteFullDaeck(deck);

            ilon.updateDeck(ilonDeck);
            mark.updateDeck(markDeck);
            
            if(derby.singleExperiment()){
                succesCounter++;
            }
        }

        return succesCounter;
    }
}