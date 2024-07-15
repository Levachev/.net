
using System.Collections.Concurrent;
using MassTransit;
using Microsoft.AspNetCore.SignalR.Protocol;
using deck;


public class ElonConsumerMarkPick : IConsumer<CardPick>
{
    public Task Consume(ConsumeContext<CardPick> context)
    {

        Util.pickNumber = context.Message.number;

        return Task.CompletedTask;
    }
}

