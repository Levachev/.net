using MassTransit;
using cardPick;


public class MarkConsumerElonPick : IConsumer<CardPick>
{
    public Task Consume(ConsumeContext<CardPick> context)
    {
        if(!context.Message.name.Equals("mark"))
        {
            return Task.CompletedTask;
        }

        Util.pickNumber = context.Message.number;
        Console.WriteLine("get elon pick " + Util.pickNumber);
        Util.isReady = true;


        return Task.CompletedTask;
    }
}

