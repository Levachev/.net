using System;
using Moq;

namespace AppTests
{
    [TestFixture]
    public class SimulatorTest
    {
        private Mock<Shuffler> shufflerMock = new Mock<Shuffler>();
        private Mock<Derby> derbyMock = new Mock<Derby>(
                (new Mock<Person>(It.IsAny<RandomStrategy>())).Object,
                (new Mock<Person>(It.IsAny<MyFirstRedStrategy>())).Object
            );

        [Test]
        public void TestSimulatorCallShuffler()
        {
            //given
            var simulator = new Simulator(100, shufflerMock.Object, derbyMock.Object);

            //when
            derbyMock.Setup(m => m.singleExperiment()).Returns(true);
            simulator.simulate();

            //then
            shufflerMock.Verify(mock => mock.shuffleDeck(It.IsAny<Deck>()), Times.Once());
        }


        [TestCase(15)]
        public void TestSimulatorCorrectResult1(int n)
        {
            //given
            var simulator = new Simulator(n, shufflerMock.Object, derbyMock.Object);

            //when\
            derbyMock.Setup(m => m.singleExperiment()).Returns(true);
            int result = simulator.simulate();

            //then
            Assert.That(result, Is.EqualTo(n));
        }

        [TestCase(15)]
        public void TestSimulatorCorrectResult2(int n)
        {
            //given
            var simulator = new Simulator(n, shufflerMock.Object, derbyMock.Object);

            //when
            derbyMock.Setup(m => m.singleExperiment()).Returns(false);
            int result = simulator.simulate();

            //then
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
