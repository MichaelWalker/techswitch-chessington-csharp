using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class WinPredictorTests
    {
        private IScoreCalculator _scoreCalculator;
        private WinPredictor _winPredictor;
        
        [SetUp]
        public void SetUp()
        {
            _scoreCalculator = A.Fake<IScoreCalculator>();
            _winPredictor = new WinPredictor(_scoreCalculator);
        }
        
        [Test]
        public void ScoresAreClose_GetWinPrediction_ReturnsCloseStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(5);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(7);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("Its very close");
        }

        [Test]
        public void BlackHasSlightLead_GetWinPrediction_ReturnsBlackHasSlightLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(4);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(7);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("Black has taken a slight lead");
        }
    }
}