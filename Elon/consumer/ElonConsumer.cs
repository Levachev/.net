
using MassTransit;
using deck;


public class ElonConsumer : IConsumer<Deck>
{
    public Task Consume(ConsumeContext<Deck> context)
    {
        System.Diagnostics.Debug.WriteLine("in consume method");
        Console.WriteLine("in console consume");

        var deck = context.Message.deck;

        Util.deck = deck;

        ICardPickStrategy strategy = new MyFirstRedStrategy();

        context.Publish(
            new CardPick(strategy.Pick(deck))
            );

        return Task.CompletedTask;
    }
}

