using System;
using System.Diagnostics.Eventing.Reader;
using Moq;

namespace AppTests
{
    [TestFixture]
    public class DerbyTest
    {
        private Mock<Shuffler> shufflerMock = new Mock<Shuffler>();
        private Mock<Person> elonMock = new Mock<Person>(It.IsAny<RandomStrategy>());
        private Mock<Person> markMock = new Mock<Person>(It.IsAny<MyFirstRedStrategy>());

        [Test]
        public void TestSimulatorCallShuffler()
        {
            //given
            var derby = new Derby(shufflerMock.Object, elonMock.Object, markMock.Object);

            //when
            elonMock.Setup(m => m.move()).Returns(0);
            markMock.Setup(m => m.move()).Returns(0);
            elonMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Red));
            markMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Red));
            derby.singleExperiment(new Deck());

            //then
            shufflerMock.Verify(mock => mock.shuffleDeck(It.IsAny<Deck>()), Times.Once());
        }


        [TestCase]
        public void TestSimulatorCorrectResult1()
        {
            //given
            var derby = new Derby(shufflerMock.Object, elonMock.Object, markMock.Object);

            //when
            elonMock.Setup(m => m.move()).Returns(0);
            markMock.Setup(m => m.move()).Returns(0);
            elonMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Red));
            markMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Red));
            bool result = derby.singleExperiment(new Deck());

            //then
            Assert.IsTrue(result);
        }

        [TestCase]
        public void TestSimulatorCorrectResult2()
        {
            //given
            var derby = new Derby(shufflerMock.Object, elonMock.Object, markMock.Object);

            //when
            elonMock.Setup(m => m.move()).Returns(0);
            markMock.Setup(m => m.move()).Returns(0);
            elonMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Red));
            markMock.Setup(m => m.getCard(It.IsAny<int>())).Returns(new Card(0, CardColor.Black));
            bool result = derby.singleExperiment(new Deck());

            //then
            Assert.IsFalse(result);
        }
    }
}
