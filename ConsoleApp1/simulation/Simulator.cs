
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;

public class Simulator : IHostedService
{
    private Shuffler shuffler;
    private Derby derby;

    private int iterationCapasity;

    public Simulator(int iterationCapasity, Shuffler shuffler, Derby derby)
    {
        this.iterationCapasity = iterationCapasity;
        this.shuffler = shuffler;
        this.derby = derby;
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
            Console.WriteLine(card.number+" "+card.color);
        }
    }

    public int simulate(){
        Deck deck = new Deck();

        int succesCounter = 0;

        shuffler.shuffleDeck(deck);

        for (int i=0;i<iterationCapasity;i++){

            (Deck ilonDeck, Deck markDeck) = separeteFullDaeck(deck);

            derby.updateDecks(ilonDeck, markDeck);
            
            if(derby.singleExperiment()){
                succesCounter++;
            }
        }
        Console.WriteLine("succes case number is " + succesCounter);
        return succesCounter;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        simulate();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}