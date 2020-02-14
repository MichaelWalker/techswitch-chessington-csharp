using System.Linq;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }

        public int GetWhiteScore()
        {
            return _board.CapturedPieces
                .Select(GetPieceValue)
                .Sum();
        }

        public int GetBlackScore()
        {
            return _board.CapturedPieces
                .Select(GetPieceValue)
                .Sum();
        }

        private static int GetPieceValue(Piece piece)
        {
            return piece switch
            {
                Pawn _ => 1,
                Knight _ => 3,
                Bishop _ => 3,
                Rook _ => 5,
                Queen _ => 9,
                _ => 0
            };
        }
    }
}