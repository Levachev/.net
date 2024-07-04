
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using Db;

public class Simulator : IHostedService
{
    private Derby derby;
    private int iterationCapasity;
    private IRepo repo;

    public Simulator(int iterationCapasity, Derby derby, IRepo repo)
    {
        this.iterationCapasity = iterationCapasity;
        this.derby = derby;
        this.repo = repo;
    }

    public int simulate(){
        //Deck deck = new Deck();

        int succesCounter = 0;

        /*for (int i=0;i<iterationCapasity;i++){
            
            if(derby.singleExperiment(deck)){
                succesCounter++;
            }
        }*/

        var decks = repo.getDecks();
        foreach(Deck deck in decks){
            if (derby.singleExperiment(deck)){
                succesCounter++;
            }
        }

        Console.WriteLine("succes case number is " + succesCounter);
        return succesCounter;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        for (int i=0;i<100;i++){
            repo.insertDeck(new Deck());
        }

        simulate();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}