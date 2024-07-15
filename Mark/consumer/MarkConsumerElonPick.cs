using MassTransit;


public class MarkConsumerElonPick : IConsumer<CardPick>
{
    public Task Consume(ConsumeContext<CardPick> context)
    {
        Util.pickNumber = context.Message.number;

        return Task.CompletedTask;
    }
}

