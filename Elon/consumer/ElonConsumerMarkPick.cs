
using MassTransit;
using cardPick;


public class ElonConsumerMarkPick : IConsumer<CardPick>
{
    public Task Consume(ConsumeContext<CardPick> context)
    {
        if (!context.Message.name.Equals("elon"))
        {
            return Task.CompletedTask;
        }
        Util.pickNumber = context.Message.number;
        Console.WriteLine("get mark pick " + Util.pickNumber);
        Util.isReady = true;


        return Task.CompletedTask;
    }
}

