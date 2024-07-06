
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using Db;
using Gods;

public class Simulator : IHostedService
{
    private Derby derby;
    private int iterationCapasity;
    private IRepo repo;
    private God god;

    public Simulator(int iterationCapasity, Derby derby, IRepo repo, God god)
    {
        this.iterationCapasity = iterationCapasity;
        this.derby = derby;
        this.repo = repo;
        this.god = god;
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

    public async Task<int> simulateWeb()
    {
        int succesCounter = 0;

        var decks = repo.getDecks();
        foreach (Deck deck in decks)
        {
            if (await god.singleExperiment(deck))
            {
                succesCounter++;
            }
        }

        Console.WriteLine("succes case number is " + succesCounter);
        return succesCounter;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        for (int i=0;i<10;i++){
            repo.insertDeck(new Deck());
        }

        Console.WriteLine("after add decks");

        int result = simulateWeb().Result;
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}