using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class ScoreCalculatorTests
    {
        [Test]
        public void GetWhiteScore_ReturnsZeroIfNoPiecesAreCaptured()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>());

            var whiteScore = scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(0);
        }
        
        [Test]
        public void GetBlackScore_ReturnsZeroIfNoPiecesAreCaptured()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>());

            var whiteScore = scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(0);
        }
    }
}