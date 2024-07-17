
using MassTransit;
using cardPick;
using deckMessage;


public class MarkConsumer : IConsumer<DeckMessage>
{
    public Task Consume(ConsumeContext<DeckMessage> context)
    {
        var deck = context.Message.deck;

        Util.deck = deck.deck;

        ICardPickStrategy strategy = new RandomStrategy();
        int pick = strategy.Pick(deck.deck);
        Console.WriteLine("mark pick " + pick);

        context.Publish<CardPick>(
            new CardPick(pick, "elon")
            );

        return Task.CompletedTask;
    }
}

