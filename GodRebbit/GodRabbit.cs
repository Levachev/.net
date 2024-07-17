using MassTransit;
using deck;
using deckMessage;


namespace Gods
{
    public class GodRabbit
    {
        private int elonPort = 8001;
        private int markPort = 8002;
        private HttpClient client = new HttpClient();
        private Shuffler shuffler;
        private IBusControl busControl;
        private ISendEndpoint endpointElon;
        private ISendEndpoint endpointMark;


        public GodRabbit(Shuffler shuffler)
        {
            this.shuffler = shuffler;
            busControl = Bus.Factory.CreateUsingRabbitMq(async cfg =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                }); 
            });
            busControl.Start();
            endpointElon = busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/elonQueue")).Result;
            endpointMark = busControl.GetSendEndpoint(new Uri("rabbitmq://localhost/markQueue")).Result;
        }

        public async Task<bool> singleExperiment(Deck deck)
        {
            shuffler.shuffleDeck(deck);

            (Deck elonDeck, Deck markDeck) = separeteFullDaeck(deck);

            await sendDeckElon(elonDeck);
            await sendDeckMark(markDeck);
            
            CardColor elonColor = await getColor(elonPort);
            CardColor markColor = await getColor(markPort);
            
            return elonColor == markColor;
        }

        public async Task sendDeckElon(Deck deck)
        {
            await endpointElon.Send<DeckMessage>(new{deck});
        }

        public async Task sendDeckMark(Deck deck)
        {
            await endpointMark.Send<DeckMessage>(new{deck});
        }

        private async Task<CardColor> getColor(int port)
        {
            var uri = "http://localhost:" + port + "/player/color";
            using var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return CardColor.Black;
            }

            return Enum.Parse<CardColor>(
                Convert.ToString(
                    await response.Content.ReadAsStringAsync()
                    )
                );
        }

        private (Deck, Deck) separeteFullDaeck(Deck deck)
        {
            int deckSize = deck.getSize();
            Card[] ilonCards = new Card[deckSize / 2];
            Card[] markCards = new Card[deckSize / 2];
            for (int i = 0; i < deckSize / 2; i++)
            {
                ilonCards[i] = deck.getCard(i);
                markCards[i] = deck.getCard(deckSize / 2 + i);
            }
            Deck ilonDeck = new Deck(ilonCards);
            Deck markDeck = new Deck(markCards);

            return (ilonDeck, markDeck);
        }
    }
}
