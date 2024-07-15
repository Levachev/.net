
using System.Collections.Concurrent;
using MassTransit;
using Microsoft.AspNetCore.SignalR.Protocol;
using deck;


public class MarkConsumer : IConsumer<Deck>
{
    public Task Consume(ConsumeContext<Deck> context)
    {
        System.Diagnostics.Debug.WriteLine("in consume method");
        Console.WriteLine("in console consume");
        var deck = context.Message.deck;

        Util.deck = deck;

        ICardPickStrategy strategy = new RandomStrategy();

        context.Publish(
            new CardPick(strategy.Pick(deck))
            );

        return Task.CompletedTask;
    }
}

