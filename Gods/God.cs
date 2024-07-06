using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Gods
{
    public class God
    {
        private int elonPort = 8001;
        private int markPort = 8002;
        private HttpClient client = new HttpClient();
        private Shuffler shuffler;

        public God(Shuffler shuffler)
        {
            this.shuffler = shuffler;
        }

        public async Task<bool> singleExperiment(Deck deck)
        {
            shuffler.shuffleDeck(deck);

            (Deck elonDeck, Deck markDeck) = separeteFullDaeck(deck);

            int elonResult = await result(elonDeck, elonPort);
            int markResult = await result(markDeck, markPort);

            var elonPick = elonDeck.getCard(markResult);
            var markPick = markDeck.getCard(elonResult);

            return elonPick.color == markPick.color;
        }

        private async Task<int> result(Deck deck, int port)
        {
            Console.WriteLine(createUri(port));
            using var response = await client.PostAsync(createUri(port),
                new StringContent(
                    JsonConvert.SerializeObject(deck.deck), Encoding.UTF8, "application/json")
                );

            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("-1");
                return -1;
            }

            return Convert.ToInt32(await response.Content.ReadAsStringAsync());
        }

        private string createUri(int port)
        {
            return "http://localhost:" + port + "/player/result";
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
