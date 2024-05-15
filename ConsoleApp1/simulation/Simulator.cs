

using System.Runtime.InteropServices;

class Simulator {
    private int iterationCapasity;

    public Simulator(int iterationCapasity){
        this.iterationCapasity = iterationCapasity;
    }

    private (Deck, Deck) separeteFullDaeck(Deck deck){
        int deckSize = deck.getSize();
        List<Card> ilonCards = new List<Card>();
        List<Card> markCards = new List<Card>();
        for(int i=0;i<deckSize/2;i++){
            ilonCards.Add(deck.getCard(i));
            markCards.Add(deck.getCard(deckSize/2+i));
        }
        Deck ilonDeck = new Deck(ilonCards);
        Deck markDeck = new Deck(markCards);

        return (ilonDeck, markDeck);
    }

    private void printDeck(List<Card> deck){
        foreach(Card card in deck){
            Console.WriteLine(card.GetCardValue()+" "+card.GetSuit());
        }
    }

    public int simulate(string ilonStrategyName, string markStrategyName){
        Deck deck = Generator.generateDeck();

        Strategy ilonStrategy = StrategyFactory.createForName(ilonStrategyName);
        Strategy markStrategy = StrategyFactory.createForName(markStrategyName);

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