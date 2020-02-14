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
        
        [Test]
        public void WhiteHasSlightLead_GetWinPrediction_ReturnsWhiteHasSlightLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(11);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(8);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("White has taken a slight lead");
        }
        
        [Test]
        public void BlackHasLead_GetWinPrediction_ReturnsBlackHasLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(1);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(7);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("Black is winning");
        }
        
        [Test]
        public void WhiteHasLead_GetWinPrediction_ReturnsWhiteHasLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(14);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(8);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("White is winning");
        }
        
        [Test]
        public void BlackHasLargeLead_GetWinPrediction_ReturnsBlackHasLargeLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(1);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(11);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("Black is way ahead");
        }
        
        [Test]
        public void WhiteHasLargeLead_GetWinPrediction_ReturnsWhiteHasLargeLeadStatement()
        {
            A.CallTo(() => _scoreCalculator.GetWhiteScore()).Returns(18);
            A.CallTo(() => _scoreCalculator.GetBlackScore()).Returns(8);

            var prediction = _winPredictor.GetWinPrediction();

            prediction.Should().Be("White is way ahead");
        }
    }
}