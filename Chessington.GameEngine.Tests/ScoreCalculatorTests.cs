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
        private readonly Pawn _blackPawn = new Pawn(Player.Black);
        private readonly Knight _whiteKnight = new Knight(Player.White);
        private readonly Bishop _blackBishop = new Bishop(Player.Black);
        private readonly Rook _whiteRook = new Rook(Player.White);
        private readonly Queen _blackQueen = new Queen(Player.Black);
        
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

            var whiteScore = scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(0);
        }

        [Test]
        public void PawnsAreWorthOne()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>
            {
                _blackPawn,
            });

            var whiteScore = scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(1);
        }
        
        [Test]
        public void KnightsAreWorthThree()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>
            {
                _whiteKnight
            });

            var whiteScore = scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(3);
        }
        
        [Test]
        public void BishopsAreWorthThree()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>
            {
                _blackBishop
            });

            var whiteScore = scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(3);
        }
        
        [Test]
        public void RooksAreWorthFive()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>
            {
                _whiteRook
            });

            var whiteScore = scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(5);
        }
        
        [Test]
        public void QueensAreWorthNine()
        {
            var board = A.Fake<IBoard>();
            var scoreCalculator = new ScoreCalculator(board);
            A.CallTo(() => board.CapturedPieces).Returns(new List<Piece>
            {
                _blackQueen
            });

            var whiteScore = scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(9);
        }
    }
}