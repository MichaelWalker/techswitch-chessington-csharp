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

        private IBoard _board;
        private ScoreCalculator _scoreCalculator;
        
        [SetUp]
        public void SetUp()
        {
            _board = A.Fake<IBoard>();
            _scoreCalculator = new ScoreCalculator(_board);
        }
        
        [Test]
        public void GetWhiteScore_ReturnsZeroIfNoPiecesAreCaptured()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>());

            var whiteScore = _scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(0);
        }
        
        [Test]
        public void GetBlackScore_ReturnsZeroIfNoPiecesAreCaptured()
        {

            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>());

            var whiteScore = _scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(0);
        }

        [Test]
        public void PawnsAreWorthOne()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _blackPawn,
            });

            var whiteScore = _scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(1);
        }
        
        [Test]
        public void KnightsAreWorthThree()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _whiteKnight
            });

            var whiteScore = _scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(3);
        }
        
        [Test]
        public void BishopsAreWorthThree()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _blackBishop
            });

            var whiteScore = _scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(3);
        }
        
        [Test]
        public void RooksAreWorthFive()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _whiteRook
            });

            var whiteScore = _scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(5);
        }
        
        [Test]
        public void QueensAreWorthNine()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _blackQueen
            });

            var whiteScore = _scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(9);
        }

        [Test]
        public void GetWhiteScore_CountsOnlyCapturedBlackPieces()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _blackPawn,
                _blackBishop,
                _blackQueen,
                _whiteKnight,
                _whiteRook,
            });

            var whiteScore = _scoreCalculator.GetWhiteScore();

            whiteScore.Should().Be(13);
        }
        
        [Test]
        public void GetBlackScore_CountsOnlyCapturedWhitePieces()
        {
            A.CallTo(() => _board.CapturedPieces).Returns(new List<Piece>
            {
                _blackPawn,
                _blackBishop,
                _blackQueen,
                _whiteKnight,
                _whiteRook,
            });

            var whiteScore = _scoreCalculator.GetBlackScore();

            whiteScore.Should().Be(8);
        }
    }
}