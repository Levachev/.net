
using MassTransit;
using deckMessage;
using cardPick;


public class ElonConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {

        var deck = context.Message.deck;

        Util.deck = deck.deck;

        ICardPickStrategy strategy = new MyFirstRedStrategy();

        int pick = strategy.Pick(deck.deck);
        Console.WriteLine("elon pick " + pick);
        context.Publish<CardPick>(
            new CardPick(pick, "mark")
            );

        return Task.CompletedTask;
    }
}

